using TCP_UDP_test.Models;
using TCP_UDP_test.Networking.TCP;
using TCP_UDP_test.Networking.UDP;

namespace TCP_UDP_test.Networking
{
  internal static class Network
  {
    private static INetworkHandler? OpenNetwork;

    public static void StopOpenNetwork()
    {
      if (OpenNetwork != null) OpenNetwork.Stop();
    }

    public static void StartTCPSerer<T>(LobbyInfo lobbyInfo) where T : INetworkHandler
    {
      if (OpenNetwork != null) return;
      OpenNetwork = (T)Activator.CreateInstance(typeof(T), lobbyInfo);
      OpenNetwork?.Start();
    }

    public static void SendPackage(Packet packet)
    {
      if (OpenNetwork == null) return;
      OpenNetwork.SendPackage(packet);
    }
  }
}
