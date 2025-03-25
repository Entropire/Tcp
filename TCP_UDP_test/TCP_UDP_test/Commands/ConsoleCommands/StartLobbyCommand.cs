namespace TCP_UDP_test.Commands.ConsoleCommands
{

  [CommandName("StartLobby")]
  internal class StartLobbyCommand : Command
  {
    public override void Execute(string[] args)
    {
      if (args.Length < 5)
      {
        Console.WriteLine("usage: /StartLobby [lobbyName] [lobbyDescription] [ip] [port]");
        return;
      }

      Console.WriteLine($"started a lobby with: {args[1]}, {args[2]}, {args[3]}, {args[4]},");
    }
  }
}
