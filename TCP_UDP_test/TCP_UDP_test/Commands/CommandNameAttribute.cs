﻿using System;

namespace TCP_UDP_test.Commands
{
  [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
  internal class CommandNameAttribute : Attribute
  {
    public string Name { get; }

    public CommandNameAttribute(string name)
    {
      Name = name;
    }
  }
}
