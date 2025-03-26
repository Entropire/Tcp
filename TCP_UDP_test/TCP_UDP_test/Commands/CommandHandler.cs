using System.Reflection;

namespace TCP_UDP_test.Commands
{
  internal static class CommandHandler
  {
    private static Dictionary<string, Command> commandList = new Dictionary<string, Command>();

    public static void InitializeCommands()
    {
      foreach (Type commandType in GetClassesImplementingInterface(typeof(Command)))
      {
        if (commandType.BaseType != typeof(Command)) continue;

        Command? command = Activator.CreateInstance(commandType) as Command;
        var attribute = commandType.GetCustomAttribute<CommandNameAttribute>();

        if (command == null || attribute == null)
        {
          continue;
        }

        foreach (string name in attribute.Names)
        {
          string lowerName = name.ToLower();
          if (!commandList.ContainsKey(lowerName))
          {
            commandList.Add(lowerName, command);
          }
          else
          {
            Console.WriteLine($"Warning: Duplicate command name '{lowerName}' ignored.");
          }
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
