using System.Net;

namespace Server;

internal class Program
{

  public static void Main(string[] args)
  {
    CancellationTokenSource cts = new CancellationTokenSource();
    CancellationToken ct = cts.Token;

    Host host = new Host();
    host.onMessage += (msg) => Console.WriteLine(msg);
    host.onConnected += () => host.SendPacket(PacketType.Message, "gggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

    Client client = new Client();
    client.onMessage += (msg) => Console.WriteLine(msg);
    client.onConnected += () => client.SendPacket(PacketType.Message, "gggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

    host.onReady += () =>
    {
      client.Start(IPAddress.Parse("127.0.0.1"), 8080, ct);
    };

    host.Start(IPAddress.Parse("127.0.0.1"), 8080, ct);

    Console.ReadLine();
  }
}