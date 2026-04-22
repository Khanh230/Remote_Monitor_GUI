using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace RemoteMonitor_GUI;

public class ClientManager
{
    private TcpClient? _tcp;
    private NetworkStream? _stream;
    private bool _running = false;
    private bool _streaming = false;
    private readonly SemaphoreSlim _sendLock = new(1, 1);

    public event Action<string>? OnLog;
    public event Action<bool>? OnConnectionChanged;

    public async Task ConnectAsync(string ip, int port)
    {
        _tcp = new TcpClient();
        await _tcp.ConnectAsync(ip, port);
        _stream = _tcp.GetStream();
        _running = true;
        OnConnectionChanged?.Invoke(true);
        OnLog?.Invoke($"Connected to {ip}:{port}");

        var info = $"Host={Environment.MachineName}; User={Environment.UserName}; OS={Environment.OSVersion}";
        await SendPacketAsync(PacketType.ClientInfo, System.Text.Encoding.UTF8.GetBytes(info));

        _ = Task.Run(ReceiveLoopAsync);
    }

    public void Disconnect()
    {
        _running = false;
        _streaming = false;
        _tcp?.Close();
        OnConnectionChanged?.Invoke(false);
        OnLog?.Invoke("Disconnected.");
    }

    private async Task ReceiveLoopAsync()
    {
        try
        {
            while (_running && _tcp!.Connected)
            {
                var packet = await PacketHelper.ReadPacketAsync(_stream!);
                if (packet == null) break;

                switch (packet.Type)
                {
                    case PacketType.RequestScreenshot:
                        await CaptureAndSendAsync();
                        break;
                    case PacketType.StreamControl:
                        _streaming = packet.Data[0] == 1;
                        OnLog?.Invoke($"Stream: {(_streaming ? "ON" : "OFF")}");
                        if (_streaming) _ = Task.Run(StreamLoopAsync);
                        break;
                    case PacketType.ChatMessage:
                        OnLog?.Invoke(System.Text.Encoding.UTF8.GetString(packet.Data));
                        break;
                }
            }
        }
        catch { }
        finally
        {
            OnConnectionChanged?.Invoke(false);
            OnLog?.Invoke("Connection lost.");
        }
    }

    private async Task StreamLoopAsync()
    {
        while (_streaming && _tcp?.Connected == true)
        {
            await CaptureAndSendAsync();
            await Task.Delay(1000);
        }
    }

    private async Task CaptureAndSendAsync()
    {
        var data = ScreenCapture.CaptureScreen();
        await SendPacketAsync(PacketType.ScreenshotData, data);
    }

    public async Task SendChatAsync(string message)
    {
        var msg = $"[{Environment.MachineName}]: {message}";
        await SendPacketAsync(PacketType.ChatMessage,
            System.Text.Encoding.UTF8.GetBytes(msg));
        OnLog?.Invoke($"[You]: {message}");
    }

    private async Task SendPacketAsync(PacketType type, byte[] data)
    {
        if (_stream == null) return;
        await _sendLock.WaitAsync();
        try { await PacketHelper.WritePacketAsync(_stream, type, data); }
        finally { _sendLock.Release(); }
    }

    public bool IsConnected => _tcp?.Connected == true;
}