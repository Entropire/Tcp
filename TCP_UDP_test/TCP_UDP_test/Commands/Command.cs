using System.Reflection;

namespace TCP_UDP_test.Commands
{
  internal abstract class Command : ICommand
  {
    protected Command()
    {
      var attribute = GetType().GetCustomAttribute<CommandNameAttribute>();
      if (attribute == null)
      {
        throw new InvalidOperationException($"Class '{GetType().FullName}' must have a [CommandName] attribute.");
      }
    }

    public abstract void Execute(string[] args);
  }
}
