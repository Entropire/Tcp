﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_UDP_test.Commands
{
  internal interface ICommand
  {
    public void Execute(string[] args);
  }
}
