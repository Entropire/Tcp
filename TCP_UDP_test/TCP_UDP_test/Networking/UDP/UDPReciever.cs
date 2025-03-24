using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using TCP_UDP_test.Models;

namespace TCP_UDP_test.Networking.UDP
{
  internal class UDPReciever : INetworkHandler
  {
    private UdpClient _UdpClient;
    private bool RevieveDataActive = false;
    
    public void Start()
    {
      _UdpClient = new UdpClient(9876);
      _UdpClient.EnableBroadcast = true;
      RevieveDataActive = true;
      RecieveLobbyInfo();
    }

    public void Stop()
    {
      RevieveDataActive = false;
      _UdpClient?.Dispose();
    }

    private async void RecieveLobbyInfo()
    {
      Console.Clear();
      Console.WriteLine("Recieving data");
      while (RevieveDataActive)
      {
        UdpReceiveResult receiveResult = await _UdpClient.ReceiveAsync();
        Packet packet = JsonSerializer.Deserialize<Packet>(Encoding.UTF8.GetString(receiveResult.Buffer));

        if (packet != null)
        {
          PacketHandler.TriggerEventForPacket(packet);
        }
      }
    }
  }
}
