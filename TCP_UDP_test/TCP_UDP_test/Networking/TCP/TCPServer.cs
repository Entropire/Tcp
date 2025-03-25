using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using TCP_UDP_test.Models;
using TCP_UDP_test.Networking.UDP;

namespace TCP_UDP_test.Networking.TCP
{
  internal class TCPServer : INetworkHandler
  {
    private TcpListener _TcpListener;
    private UDPbroadcaster _UDPBroadcaster;
    private LobbyInfo LobbyInfo;
    private bool HandleClients;

    internal TCPServer(LobbyInfo lobbyInfo)
    {
      LobbyInfo = lobbyInfo;
    }

    public void Start()
    {
      _TcpListener = new TcpListener(IPAddress.Parse(LobbyInfo.ip), LobbyInfo.port);
      _TcpListener.Start();
      _UDPBroadcaster = new UDPbroadcaster(LobbyInfo);
      _UDPBroadcaster.Start();
      HandleClients = true;
      ListenForClients();
    }

    public void Stop()
    {
      _UDPBroadcaster?.Stop();
      HandleClients = false;
      _TcpListener?.Dispose(); ;
    }

    public async void ListenForClients()
    {
      while (HandleClients)
      {
        try
        {
          TcpClient client = await _TcpListener.AcceptTcpClientAsync();
          if (client != null)
          {
            _ = Task.Run(() => ListenForPackets(client));
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Error accepting client: {ex.Message}");
        }
      }
    }

    private async Task ListenForPackets(TcpClient client)
    {
      NetworkStream stream = client.GetStream();
      while (HandleClients)
      {
        if (!client.Connected)
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
      client.Close();
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
