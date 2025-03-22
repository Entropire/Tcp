using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using TCP_UDP_test.Models;

namespace TCP_UDP_test.Networking.TCP
{
  internal class TCPServer : INetworkHandler
  {
    private TcpListener _TcpListener;
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
      HandleClients = true;
      ListenForClients();
    }

    public void Stop()
    {
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
      byte[] buffer = new byte[1024];
      while (HandleClients)
      {
        try
        {
          int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
          if (bytesRead > 0)
          {
            Packet packet = JsonSerializer.Deserialize<Packet>(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            if (packet != null)
            {

            }
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Error reading from client: {ex.Message}");
          break;
        }
      }
      client.Close();
    }
  }
}
