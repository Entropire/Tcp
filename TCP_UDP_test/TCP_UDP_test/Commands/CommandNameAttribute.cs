using System;

namespace TCP_UDP_test.Commands
{
  [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
  public class CommandNameAttribute : Attribute
  {
    public string[] Names { get; }

    public CommandNameAttribute(params string[] names)
    {
      Names = names;
    }
  }
}
