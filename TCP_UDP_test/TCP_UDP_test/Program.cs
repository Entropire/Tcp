using System.Security;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using TCP_UDP_test.Enums;
using TCP_UDP_test.Models;
using TCP_UDP_test.Networking;
using TCP_UDP_test.Networking.UDP;

namespace TCP_UDP_test
{
  internal class Program
  {
    static void Main(string[] args) => new Program().Run();

    private void Run()
    {
      PacketHandler.Subscribe(PacketType.LobbyInfo, (content) =>
      {
        if (content != null)
        {
          LobbyInfo lobbyInfo = JsonSerializer.Deserialize<LobbyInfo>(content);
          Console.WriteLine($"Name: {lobbyInfo.name}, Description: {lobbyInfo.description}, IP: {lobbyInfo.ip}, Port: {lobbyInfo.port}");
        }
      });

      string command = Console.ReadLine();

      if (command.Equals("client"))
      {
        UDPReciever uDPReciever = new UDPReciever();
        uDPReciever.Start();
      }

      if (command.Equals("server"))
      {
        LobbyInfo lobbyInfo = new LobbyInfo("test", "This is a test lobby", "192.0.0.192", 8080);
        UDPbroadcaster uDPbroadcaster = new UDPbroadcaster(lobbyInfo);
        uDPbroadcaster.Start();
      }

      Console.ReadLine();
    }
  }
}
