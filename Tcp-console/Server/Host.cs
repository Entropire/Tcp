using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server;

internal class Host
{
    public Action<String> onMessage;

    private TcpClient client;
    private TcpListener listener;

    public void Start() => new Thread(StartTcpHost).Start();

    private async void StartTcpHost()
    {
        onMessage += (msg) => Console.WriteLine($"[Host]: {msg}");

        try
        {
            onMessage?.Invoke("Starting server...");
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            listener.Start();
            onMessage?.Invoke("Server online!");
            await ListenForClient();
            await ReceivePacket();
        }
        catch (Exception e)
        {
            onMessage?.Invoke(e.Message);
        }
        finally
        {
            listener.Stop();
            onMessage?.Invoke("Server stopped.");
        }
    }

    private async Task ListenForClient()
    {
        onMessage?.Invoke("Listening for clients");
        try
        {
            while (client == null)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();

                this.client = client;

                SendPacket(PacketType.Message, "You are connected to the server!");
                onMessage?.Invoke($"client connected");
            }
        }
        catch (Exception e)
        {
            onMessage?.Invoke(e.Message);
            throw;
        }
        finally
        {
            listener.Stop();
            onMessage?.Invoke("Server stopped");
        }
    }

    private async Task ReceivePacket()
    {
        byte[] bytes = new byte[1024];
        string data;
        int bytesRead;

        using (client)
        {
            if (client.Connected)
            {
                NetworkStream stream = client.GetStream();

                while (true)
                {
                    try
                    {
                        bytesRead = await stream.ReadAsync(bytes, 0, bytes.Length);

                        if (bytesRead <= 0)
                            continue;

                        data = Encoding.UTF8.GetString(bytes, 0, bytesRead);
                        Console.WriteLine(data);
                        Packet packet = JsonSerializer.Deserialize<Packet>(data);
                        if (packet != null)
                        {
                            onMessage?.Invoke($"client: [{packet.type}] {packet.data}");
                        }
                    }
                    catch (IOException e)
                    {
                        onMessage?.Invoke(e.Message);
                        break;
                    }
                }
            }
        }
    }

    public void SendPacket(PacketType packetType, String packetData)
    {
        if (client.Connected)
        {
            try
            {
                Packet packet = new Packet(packetType, packetData);
                byte[] data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(packet));

                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
            }
            catch (Exception e)
            {
                onMessage.Invoke($"failed to send message to the server: {e}");
                throw;
            }
        }
        else
        {
            onMessage.Invoke($"Disconnected from server");
        }
    }
}



 