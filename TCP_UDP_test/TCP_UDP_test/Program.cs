using TCP_UDP_test.Commands;
using TCP_UDP_test.Enums;
using TCP_UDP_test.Models;
using TCP_UDP_test.Networking;

namespace TCP_UDP_test
{
  internal class Program
  {
    static void Main(string[] args) => new Program().Run();

    private void Run()
    {
      CommandHandler.InitializeCommands();

      PacketHandler.Subscribe(PacketType.Message, (msg) => Console.WriteLine(msg));

      string? input;
      string[] args;
      while (true)
      {
        input = Console.ReadLine();

        if (input != null)
        {
          if (input.StartsWith("/"))
          {
            input = input.Replace("/", "");
            args = input.Split(' ');
            CommandHandler.executeCommand(args[0].ToLower(), args);
          }
          else
          {
            Packet packet = new Packet(1, PacketType.Message, input);
            Network.SendPackage(packet);
          }
        }
      }
    }
  }
}