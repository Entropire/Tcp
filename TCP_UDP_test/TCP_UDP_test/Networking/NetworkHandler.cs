using TCP_UDP_test.Models;
using TCP_UDP_test.Networking.TCP;
using TCP_UDP_test.Networking.UDP;

namespace TCP_UDP_test.Networking
{
  internal static class NetworkHandler
  {
    private static INetworkHandler? OpenNetwork;

    public static void StopOpenNetwork()
    {
      if (OpenNetwork != null) OpenNetwork.Stop();
    }

    public static void StartTCPSerer(LobbyInfo lobbyInfo)
    {
      if (OpenNetwork != null) return;
      OpenNetwork = new TCPServer(lobbyInfo);
      OpenNetwork.Start();
    }

    public static void StartTCPClient(LobbyInfo lobbyInfo)
    {
      if (OpenNetwork != null) return;
      OpenNetwork = new TCPClient(lobbyInfo);
      OpenNetwork.Start();
    }

    public static void StartUDPReciever()
    {
      if (OpenNetwork != null) return;
      OpenNetwork = new UDPReciever();
      OpenNetwork.Start();
    }

    public static void SendPackage(Packet packet)
    {
      if (OpenNetwork == null) return;
    }
  }
}
