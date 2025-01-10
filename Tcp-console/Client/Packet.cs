using System;

namespace Client;

public class Packet
{
    public PacketType type { get; set; }
    public String data { get; set; }
    
    public Packet(PacketType packetType, String packetData)
    {
        type = packetType;
        data = packetData;
    }
}