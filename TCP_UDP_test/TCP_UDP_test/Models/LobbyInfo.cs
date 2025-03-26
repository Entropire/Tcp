using System.Data;
using System.Net;
using TCP_UDP_test.Enums;

namespace TCP_UDP_test.Models
{
  internal record LobbyInfo
  {
    public string Name { get; init; }
    public string Description { get; init; }
    public byte[] Ip { get; init; }
    public ushort Port { get; init; }

    public LobbyInfo(string name, string description, IPAddress ip, ushort port)
    {
      if (name.Length > 40) throw new ArgumentException("Name too long", nameof(name));
      if (description.Length > 300) throw new ArgumentException("Description too long", nameof(description));

      Name = name;
      Description = description;
      Ip = ip.GetAddressBytes();
      Port = port;
    }

    public LobbyInfo(string name, string description, byte[] ip, ushort port)
    {
      if (name.Length > 40) throw new ArgumentException("Name too long", nameof(name));
      if (description.Length > 300) throw new ArgumentException("Description too long", nameof(description));

      Name = name;
      Description = description;
      Ip = ip;
      Port = port;
    }
  }
}
