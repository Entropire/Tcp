using TCP_UDP_test.Models;

namespace TCP_UDP_test.Networking
{
  internal interface INetworkHandler
  {
    public void Start();
    public void Stop();

    public void SendPackage(Packet packet);
  }
}
