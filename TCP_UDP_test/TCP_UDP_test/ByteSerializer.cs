namespace TCP_UDP_test
{
  internal static class ByteSerializer
  {
    public static byte[] Serialize<T>(T obj)
    {
      var type = obj.GetType();

      foreach (var property in type.GetProperties())
      {
        var value = property.GetValue(obj);
        
      }

      return [];
    }

    //public static T Deserialize<T>()
    //{

    //}
  }
}
