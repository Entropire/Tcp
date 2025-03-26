using System.Net;
using TCP_UDP_test.Models;
using TCP_UDP_test.Networking;

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

      LobbyInfo lobby = new LobbyInfo(args[1], args[2], IPAddress.Parse(args[3]), ushort.Parse(args[4]));
      NetworkHandler.StartTCPSerer(lobby);
    }
  }
}
