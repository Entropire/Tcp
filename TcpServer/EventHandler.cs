namespace TcpServer;

public static class EventHandler
{
    private static Dictionary<EventTypes, Action<object[]>> events = new Dictionary<EventTypes, Action<object[]>>();
    
    public static void RegisterEvent(EventTypes eventName, Action<object[]> action)
    {
        if (events.ContainsKey(eventName))
        {
            events[eventName] += action;
        }
        else
        {
            events.Add(eventName, action);
        }
    }

    public static void UnRegisterEvent(EventTypes eventName, Action<object[]> action)
    {
        if (events.ContainsKey(eventName))
            return;
            
        if ((events[eventName].GetInvocationList()?.Length ?? 0) < 1)
        {
            events.Remove(eventName);
        }
        else
        {
            events[eventName] -= action;
        }
    }

    public static void Invoke(EventTypes eventName, params object[] data)
    {
        events[eventName].Invoke(data);
    }
    
}