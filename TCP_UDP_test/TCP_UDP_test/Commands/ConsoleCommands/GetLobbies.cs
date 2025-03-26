using TCP_UDP_test.Networking;

namespace TCP_UDP_test.Commands.ConsoleCommands
{
  [CommandName("GetLobbies")]
  internal class GetLobbies : Command
  {
    public override void Execute(string[] args)
    {
      NetworkHandler.StartUDPReciever();
    }
  }
}
