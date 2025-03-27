using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TCP_UDP_test.Models;
using TCP_UDP_test.Networking;

namespace TCP_UDP_test.Commands.ConsoleCommands
{
  [CommandName("Lobby", "L")]
  internal class LobbyCommand : Command
  {
    public override void Execute(string[] args)
    {
      if (args.Length < 1) return;

      switch(args[1])
      {
        case "start": StartLobby(args); break;
        case "stop": StopLobby(args); break;
        case "join": JoinLobby(args); break;
        case "leave": LeaveLobby(args); break;
        default: Console.WriteLine("Uknown command!"); break;
      }
    }

    private void StartLobby(string[] args)
    {
      if (args.Length < 6)
      {
        Console.WriteLine("usage: /Lobby Start [lobbyName] [lobbyDescription] [ip] [port]");
        return;
      }

      LobbyInfo lobby = new LobbyInfo(args[2], args[3], IPAddress.Parse(args[4]), ushort.Parse(args[5]));
      Network.StartTCPSerer(lobby);
    }

    private void StopLobby(string[] args)
    {
      Network.StopOpenNetwork();
    }

    private void JoinLobby(string[] args)
    {
      if (args.Length < 4)
      {
        Console.WriteLine("usage: /Lobby Join [ip] [port]");
        return;
      }

      LobbyInfo lobby = new LobbyInfo("", "", IPAddress.Parse(args[2]), ushort.Parse(args[3]));
      Network.StartTCPClient(lobby);
    }

    private void LeaveLobby(string[] args)
    {
      Network.StopOpenNetwork();
    }
  }
}
