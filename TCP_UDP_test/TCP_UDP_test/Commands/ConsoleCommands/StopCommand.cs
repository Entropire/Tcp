﻿namespace TCP_UDP_test.Commands.ConsoleCommands
{
  [CommandName("Stop", "exit")]
  internal class StopCommand : Command
  {
    public override void Execute(params string[] args)
    {
      Environment.Exit(0);
    }
  }
}

