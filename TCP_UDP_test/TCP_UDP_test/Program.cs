using TCP_UDP_test.Commands;

namespace TCP_UDP_test
{
  internal class Program
  {
    static void Main(string[] args) => new Program().Run();

    private void Run()
    {
      string input;
      string[] args;
      while (true)
      {
        input = Console.ReadLine();

        if (input.StartsWith("/"))
        {
          input = input.Replace("/", "");
          args = input.Split(' ');
          CommandHandler.executeCommand(args[0].ToLower(), args);
        }
      }
    }
  }
}