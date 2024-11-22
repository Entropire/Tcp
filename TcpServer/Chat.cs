namespace TcpServer;

public static class Chat
{
    public static Chat()
    {
        EventHandler.RegisterEvent(EventTypes.MessageReceived, OnMessageReceived);
    }

    public static void OnMessageReceived(object[] args)
    {
        Console.Write($"client {args[0]}: {args[1]}");
    }
}