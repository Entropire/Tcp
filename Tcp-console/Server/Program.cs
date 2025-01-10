using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace Server;

internal class Program
{

    public static void Main(string[] args)
    {
        new Host().Start();

        new Client().Start();

        Console.ReadLine();
    }
}