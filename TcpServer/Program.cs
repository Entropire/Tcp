using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpServer;

public class Program
{
    private TcpListener listener;
    private Dictionary<int, TcpClient> clients = new(); //<int: id, TcpClient: client>
    
    public static void Main(string[] args)
    {
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

        while(true)
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
                Console.WriteLine($"Client {id} connected");
                
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

        try
        {
            while (true)
            {
                if (!client.Connected)
                    continue;
                
                NetworkStream stream = client.GetStream();

                bytesRead = await stream.ReadAsync(bytes, 0, bytes.Length);

                if (bytesRead <= 0)
                    continue;

                data = Encoding.UTF8.GetString(bytes, 0, bytesRead);
                Console.WriteLine($"client {id}: {data}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            clients.Remove(id);
            Console.WriteLine($"Client with id {id} disconnected");
        }
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

