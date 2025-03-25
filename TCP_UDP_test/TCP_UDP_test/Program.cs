using System.Net.Sockets;
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
    TcpClient tcpClient; 

    static void Main(string[] args) => new Program().Run();

    private void Run()
    {
      while (true)
      {
        string input = Console.ReadLine();

        if (input.StartsWith("/"))
        {

        }
        else
        {
          
        }
      }
    }

    public void StartServer()
    {
      LobbyInfo lobbyInfo = new LobbyInfo("test", "This is a test lobby", "192.0.0.192", 8080);
      UDPbroadcaster uDPbroadcaster = new UDPbroadcaster(lobbyInfo);
      uDPbroadcaster.Start();
    }

    public void StartClient()
    {
      UDPReciever uDPReciever = new UDPReciever();
      uDPReciever.Start();
    }
  }
}

//PacketHandler.Subscribe(PacketType.LobbyInfo, (content) =>
//{
//  if (content != null)
//  {
//    LobbyInfo lobbyInfo = JsonSerializer.Deserialize<LobbyInfo>(content);
//    Console.WriteLine($"Name: {lobbyInfo.name}, Description: {lobbyInfo.description}, IP: {lobbyInfo.ip}, Port: {lobbyInfo.port}");
//  }
//});

//PacketHandler.Subscribe(PacketType.Message, (content) =>
//{
//  if (content != null)
//  {
//    Console.WriteLine(content);
//  }
//});