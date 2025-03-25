using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_UDP_test.Commands
{

  [CommandName("StartServer")]
  internal class StartServerCommand : Command
  {
    public override void Execute(string[] args)
    {
      Console.WriteLine("command executed");
    }
  }
}
