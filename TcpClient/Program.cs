using System.Net.Sockets;
using System.Text;

public class Program
{
    TcpClient client;
    private bool runProgram = true;
    
    public static void Main(string[] args)
    {
        Program program = new Program();
        program.Start();
    }

    private void Start()
    {
        ConnectToServer();
        while(runProgram)
        {
            string message = Console.ReadLine();

            if (string.IsNullOrEmpty(message))
                continue;
            
            if (message == "quit")
            {
                runProgram = false;
            }
            else
            {
                SendMessage(message);   
            }
        }
        
        client.Close();
    }

    private void ConnectToServer()
    {
        try
        {
            client = new TcpClient();
            client.Connect("127.0.0.1", 8080);
            Console.WriteLine("Connected to server");

            Task.Run(ReceiveData);
        }
        catch (Exception e)
        {
            Console.WriteLine($"You have been disconnected from the server: {e}");
            throw;
        }
    }

    private async void ReceiveData()
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

                if (bytesRead > 0)
                {
                    data = Encoding.UTF8.GetString(bytes, 0, bytesRead);
                    Console.WriteLine($"Server: {data}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            Console.WriteLine($"Disconnected from server");
        }
    }
    
    private void SendMessage(string message)
    {
        if (client.Connected)
        {
            try
            {
                NetworkStream stream = client.GetStream();
        
                Byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine($"failed to send message to the server: {e}");
                throw;
            }
        }
        else
        {
            Console.WriteLine($"Disconnected from server");
        }
    }
}

