using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text;
using TCP_UDP_test.Models;

namespace TCP_UDP_test.Networking.TCP
{
  internal class TCPClient : INetworkHandler
  {
    private TcpClient? _TCPClient;
    private LobbyInfo LobbyInfo;
    private bool HandleServer;

    internal TCPClient(LobbyInfo lobbyInfo)
    {
      LobbyInfo = lobbyInfo;
    }

    public void Start()
    {
      _TCPClient = new TcpClient();
      _TCPClient.Connect(IPAddress.Parse(LobbyInfo.ip), LobbyInfo.port);
      HandleServer = true;
      _ = ListenForPackets();
    }

    public void Stop()
    {
      HandleServer = false;
      _TCPClient?.Dispose();
    }

    private async Task ListenForPackets()
    {
      NetworkStream stream = _TCPClient.GetStream();
      while (HandleServer)
      {
        if (!_TCPClient.Connected)
        {
          break;
        }

        if (!stream.DataAvailable)
        {
          await Task.Delay(100);
          continue;
        }

        Packet packet = await ReadPacket(stream);
        if (packet != null)
        {
          PacketHandler.TriggerEventForPacket(packet);
        }
      }
    }

    private async Task<Packet> ReadPacket(Stream stream)
    {
      try
      {
        byte[] lenghtBuffer = new byte[4];
        stream.Read(lenghtBuffer, 0, 4);
        int messageLenth = BitConverter.ToInt32(lenghtBuffer, 0);

        byte[] messageBuffer = new byte[messageLenth];
        int totalBytesRead = 0;

        while (totalBytesRead < messageLenth)
        {
          int bytesRead = stream.Read(messageBuffer, totalBytesRead, messageLenth - totalBytesRead);

          if (bytesRead == 0)
          {
            break;
          }

          totalBytesRead += bytesRead;
        }
        string jsonString = Encoding.UTF8.GetString(messageBuffer);
        return JsonSerializer.Deserialize<Packet>(jsonString);
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}
