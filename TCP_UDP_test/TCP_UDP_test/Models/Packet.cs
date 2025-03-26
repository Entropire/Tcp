using TCP_UDP_test.Enums;

namespace TCP_UDP_test.Models
{
  internal record Packet
  {
    public int Version { get; init; }
    public PacketType PacketType { get; init; }
    public string Content { get; init; }

    public Packet() { }

    public Packet(int version, PacketType packetType, string content)
    {
      if (version <= 0)
      {
        throw new ArgumentOutOfRangeException(nameof(version), "Version must be a positive integer.");
      }

      Version = version;
      PacketType = packetType;
      Content = content;
    }
  }
}
