using TCP_UDP_test.Enums;
using TCP_UDP_test.Models;

namespace TCP_UDP_test.Networking
{
  internal static class PacketHandler
  {
    private static Dictionary<PacketType, Action<string>> eventList = new Dictionary<PacketType, Action<string>>();

    public static void Subscribe(PacketType packetType, Action<string> action)
    {
      if (eventList.ContainsKey(packetType))
      {
        eventList[packetType] += action;
      }
      else
      {
        eventList[packetType] = action;
      }
    }

    public static void UnSubscribe(PacketType packetType, Action<string> action)
    {
      if (!eventList.ContainsKey(packetType)) return;

      if (eventList[packetType] != null && eventList[packetType].GetInvocationList().Length > 1)
      {
        eventList[packetType] -= action;
      }
      else
      {
        eventList.Remove(packetType);
      }
    }

    public static void TriggerEventForPacket(Packet packet)
    {
      eventList[packet.PacketType]?.Invoke(packet.Content);
    }
  }
}
