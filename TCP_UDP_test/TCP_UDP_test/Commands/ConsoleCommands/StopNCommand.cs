using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCP_UDP_test.Networking;

namespace TCP_UDP_test.Commands.ConsoleCommands
{
  [CommandName("StopN", "SN")]
  internal class StopNCommand : Command
  {
    public override void Execute(string[] args)
    {
      NetworkHandler.StopOpenNetwork();
    }
  }
}
