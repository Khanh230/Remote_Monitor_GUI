using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteMonitor_GUI;

public enum PacketType : byte
{
    RequestScreenshot = 0x01,
    ScreenshotData = 0x02,
    ChatMessage = 0x03,
    StreamControl = 0x04,
    ClientInfo = 0x05,
}

public class Packet
{
    public PacketType Type { get; set; }
    public byte[] Data { get; set; } = [];
}