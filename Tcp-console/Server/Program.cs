using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpServer;

public class Program
{
    private TcpListener listener;
    private Dictionary<int, TcpClient> clients = new();

    public static void Main(string[] args)
    {
        //EventHandler.RegisterEvent(EventTypes.ClientConnected, args => Console.WriteLine($"Client connected with id {args[0]}"));
        //EventHandler.RegisterEvent(EventTypes.ClientDisconnected, args => Console.WriteLine($"Client disconnected with id {args[0]}"));

        Program program = new Program();
        program.Start();
    }

    private void Start()
    {
        listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
        listener.Start();
        Console.WriteLine("Server started");

        Thread thread = new Thread(RunServer);
        thread.Start();

        while (true)
        {
            string message = Console.ReadLine();

            if (!string.IsNullOrEmpty(message))
            {
                BroadCastMessage(message);
            }
        }
    }

    private async void RunServer()
    {
        int i = 0;

        Console.WriteLine("Listening for clients");
        try
        {
            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                int id = i++;
                clients.Add(id++, client);

                Task.Run(() => ReceiveData(id, client));
                //EventHandler.Invoke(EventTypes.ClientConnected, id);

                SendMessage(id, "You are connected to the server!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            listener.Stop();
            Console.WriteLine("Server stopped");
        }
    }

    private async void ReceiveData(int id, TcpClient client)
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
                        Console.WriteLine("client " + id + ": " + data);
                        //EventHandler.Invoke(EventTypes.MessageReceived, data);
                    }
                    catch (IOException ex)
                    {
                        break;
                    }
                }
            }
        }

        clients.Remove(id);
        //EventHandler.Invoke(EventTypes.ClientDisconnected);
    }

    private void SendMessage(int id, string message)
    {
        if (clients.TryGetValue(id, out TcpClient client) && client != null)
        {
            if (!client.Connected)
            {
                clients.Remove(id);
                return;
            }

            try
            {
                NetworkStream stream = client.GetStream();

                Byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine($"failed to send message to client {id}: {e}");
                throw;
            }
        }
    }

    private void BroadCastMessage(string message)
    {
        TcpClient client;

        foreach (var clientId in clients.Keys)
        {
            client = clients[clientId];

            if (client.Connected)
            {
                SendMessage(clientId, message);
            }
            else
            {
                clients.Remove(clientId);
            }
        }
    }
}