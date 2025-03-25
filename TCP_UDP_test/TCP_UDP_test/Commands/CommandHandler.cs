using System.Reflection;

namespace TCP_UDP_test.Commands
{
  internal static class CommandHandler
  {
    private static Dictionary<string, Command> commandList = new Dictionary<string, Command>();

    static CommandHandler()
    {
      foreach (Type commandType in GetClassesImplementingInterface(typeof(Command)))
      {
        if (commandType.BaseType == typeof(Command))
        {
          Command? command = Activator.CreateInstance(commandType) as Command;
          string commandName = commandType.GetCustomAttribute<CommandNameAttribute>().Name.ToLower();

          if (command == null)
          {
            continue;
          }

          commandList.Add(commandName, command);
        }
      }
    }

    static List<Type> GetClassesImplementingInterface(Type interfaceType)
    {
      return AppDomain.CurrentDomain
          .GetAssemblies()
          .SelectMany(assembly => assembly.GetTypes())
          .Where(type => interfaceType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
          .ToList();
    }

    public static void executeCommand(string commandName, string[] args)
    {
      if (commandList.TryGetValue(commandName, out Command? command))
      {
        command.Execute(args);
      }
      else
      {
        Console.WriteLine("Unkown command");
      }
    }
  }
}
