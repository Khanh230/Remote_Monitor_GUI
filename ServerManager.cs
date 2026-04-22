using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace RemoteMonitor_GUI;

public class ClientInfo
{
    public string Id { get; set; } = "";
    public string EndPoint { get; set; } = "";
    public TcpClient Tcp { get; set; } = null!;
    public NetworkStream Stream { get; set; } = null!;
    public DateTime ConnectedAt { get; set; }
    public SemaphoreSlim SendLock { get; } = new(1, 1);
}

public class ServerManager
{
    private TcpListener? _listener;
    private bool _running = false;
    private readonly ConcurrentDictionary<string, ClientInfo> _clients = new();
    private readonly string _saveDir = "Captures";

    public event Action<string>? OnLog;
    public event Action<List<ClientInfo>>? OnClientsChanged;
    public event Action<byte[]>? OnScreenshotReceived;

    public void Start(int port)
    {
        Directory.CreateDirectory(_saveDir);
        _listener = new TcpListener(IPAddress.Any, port);
        _listener.Start();
        _running = true;
        OnLog?.Invoke($"Server started on port {port}");
        Task.Run(AcceptLoopAsync);
    }

    public void Stop()
    {
        _running = false;
        _listener?.Stop();
        foreach (var c in _clients.Values) c.Tcp.Close();
        _clients.Clear();
        OnLog?.Invoke("Server stopped.");
        OnClientsChanged?.Invoke([]);
    }

    private async Task AcceptLoopAsync()
    {
        while (_running)
        {
            try
            {
                var tcp = await _listener!.AcceptTcpClientAsync();
                _ = Task.Run(() => HandleClientAsync(tcp));
            }
            catch { break; }
        }
    }

    private async Task HandleClientAsync(TcpClient tcp)
    {
        var ep = tcp.Client.RemoteEndPoint?.ToString() ?? "unknown";
        var id = ep.Replace(".", "").Replace(":", "")[^6..];
        var client = new ClientInfo
        {
            Id = id,
            EndPoint = ep,
            Tcp = tcp,
            Stream = tcp.GetStream(),
            ConnectedAt = DateTime.Now
        };
        _clients[id] = client;
        OnLog?.Invoke($"Client connected: [{id}] {ep}");
        OnClientsChanged?.Invoke(GetClients());

        try
        {
            while (tcp.Connected)
            {
                var packet = await PacketHelper.ReadPacketAsync(client.Stream);
                if (packet == null) break;
                switch (packet.Type)
                {
                    case PacketType.ScreenshotData:
                        await SaveScreenshotAsync(id, packet.Data);
                        OnScreenshotReceived?.Invoke(packet.Data);
                        OnLog?.Invoke($"Screenshot from [{id}] ({packet.Data.Length / 1024}KB)");
                        break;
                    case PacketType.ChatMessage:
                        OnLog?.Invoke($"[{id}]: {System.Text.Encoding.UTF8.GetString(packet.Data)}");
                        break;
                    case PacketType.ClientInfo:
                        OnLog?.Invoke($"Info [{id}]: {System.Text.Encoding.UTF8.GetString(packet.Data)}");
                        break;
                }
            }
        }
        catch { }
        finally
        {
            _clients.TryRemove(id, out _);
            OnLog?.Invoke($"Client disconnected: [{id}]");
            OnClientsChanged?.Invoke(GetClients());
            tcp.Close();
        }
    }

    private async Task SaveScreenshotAsync(string id, byte[] data)
    {
        var dir = Path.Combine(_saveDir, id, DateTime.Now.ToString("yyyy-MM-dd"));
        Directory.CreateDirectory(dir);
        var file = Path.Combine(dir, $"{DateTime.Now:HH-mm-ss-fff}.jpg");
        await File.WriteAllBytesAsync(file, data);
    }

    public async Task SendToAsync(string id, PacketType type, byte[] data)
    {
        if (!_clients.TryGetValue(id, out var client)) return;
        await client.SendLock.WaitAsync();
        try { await PacketHelper.WritePacketAsync(client.Stream, type, data); }
        finally { client.SendLock.Release(); }
    }

    public async Task SendToAllAsync(PacketType type, byte[] data)
    {
        foreach (var c in _clients.Values)
            await SendToAsync(c.Id, type, data);
    }

    public void KickClient(string id)
    {
        if (_clients.TryGetValue(id, out var c)) c.Tcp.Close();
    }

    public List<ClientInfo> GetClients() => [.. _clients.Values];
}