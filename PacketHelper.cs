using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Sockets;

namespace RemoteMonitor_GUI;

public static class PacketHelper
{
    public static async Task WritePacketAsync(NetworkStream stream, PacketType type, byte[] data)
    {
        var header = new byte[5];
        header[0] = (byte)type;
        BitConverter.TryWriteBytes(header.AsSpan(1), data.Length);
        await stream.WriteAsync(header);
        if (data.Length > 0)
            await stream.WriteAsync(data);
    }

    public static async Task<Packet?> ReadPacketAsync(NetworkStream stream)
    {
        var header = new byte[5];
        if (!await ReadExactAsync(stream, header, 5)) return null;
        var type = (PacketType)header[0];
        var length = BitConverter.ToInt32(header, 1);
        var data = new byte[length];
        if (length > 0 && !await ReadExactAsync(stream, data, length)) return null;
        return new Packet { Type = type, Data = data };
    }

    private static async Task<bool> ReadExactAsync(NetworkStream stream, byte[] buffer, int count)
    {
        int received = 0;
        while (received < count)
        {
            int n = await stream.ReadAsync(buffer.AsMemory(received, count - received));
            if (n == 0) return false;
            received += n;
        }
        return true;
    }
}