using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using TCP_UDP_test.Enums;
using TCP_UDP_test.Models;

namespace TCP_UDP_test.Networking.UDP
{
  internal class UDPbroadcaster : INetworkHandler
  {
    private UdpClient _UdpClient;
    private bool BroadcastActive = false;
    private LobbyInfo LobbyInfo;

    internal UDPbroadcaster(LobbyInfo lobbyInfo)
    {
      LobbyInfo = lobbyInfo;
    }

    public void Start()
    {
      _UdpClient = new UdpClient();
      _UdpClient.EnableBroadcast = true;
      BroadcastActive = true;
      BroadcastLobbyInfo();
    }

    public void Stop()
    {
      BroadcastActive = false;
      _UdpClient?.Dispose();
    }

    private async void BroadcastLobbyInfo()
    {
      IPEndPoint broadcastEndPoint = new IPEndPoint(IPAddress.Broadcast, 9876);

      Packet packet = new Packet(1, PacketType.LobbyInfo, JsonSerializer.Serialize(LobbyInfo));
      var data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(packet));

      while (BroadcastActive)
      {
        _UdpClient.Send(data, data.Length, broadcastEndPoint);
        Console.WriteLine("send lobby info");
        await Task.Delay(1000);
      }
    }
  }
}
