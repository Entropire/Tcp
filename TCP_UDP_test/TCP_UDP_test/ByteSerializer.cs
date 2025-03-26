using System.Net;
using System.Text;

namespace TCP_UDP_test
{
  internal static class ByteSerializer
  {
    public static byte[] Serialize<T>(T obj)
    {
      var type = obj.GetType();
      List<byte> endBytes = new List<byte>();

      foreach (var property in type.GetProperties())
      {
        byte[] bytes = null;
        var value = property.GetValue(obj);

        if (value == null)
        {
          bytes = BitConverter.GetBytes(0); // Null case
        }
        else if (value is int intValue)
        {
          bytes = SerializeValue(intValue);
        }
        else if (value is float floatValue)
        {
          bytes = SerializeValue(floatValue);
        }
        else if (value is double doubleValue)
        {
          bytes = SerializeValue(doubleValue);
        }
        else if (value is string stringValue)
        {
          bytes = SerializeValue(stringValue);
        }
        else if (value is bool boolValue)
        {
          bytes = SerializeValue(boolValue);
        }
        else if (value is byte[] byteArrayValue)
        {
          bytes = SerializeValue(byteArrayValue); // Handle byte[] serialization
        }
        else if (value is ushort ushortValue)
        {
          bytes = SerializeValue(ushortValue); // Handle ushort serialization
        }
        else
        {
          throw new InvalidOperationException("Unsupported property type");
        }

        if (bytes != null)
        {
          endBytes.AddRange(bytes);
        }
      }

      return endBytes.ToArray();
    }

    // SerializeValue for different types
    public static byte[] SerializeValue(int value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      byte[] length = BitConverter.GetBytes(bytes.Length);
      byte[] id = BitConverter.GetBytes(0); // ID for int
      return id.Concat(length).Concat(bytes).ToArray();
    }

    public static byte[] SerializeValue(float value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      byte[] length = BitConverter.GetBytes(bytes.Length);
      byte[] id = BitConverter.GetBytes(1); // ID for float
      return id.Concat(length).Concat(bytes).ToArray();
    }

    public static byte[] SerializeValue(double value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      byte[] length = BitConverter.GetBytes(bytes.Length);
      byte[] id = BitConverter.GetBytes(2); // ID for double
      return id.Concat(length).Concat(bytes).ToArray();
    }

    public static byte[] SerializeValue(string value)
    {
      byte[] bytes = Encoding.UTF32.GetBytes(value);
      byte[] length = BitConverter.GetBytes(bytes.Length);
      byte[] id = BitConverter.GetBytes(3); // ID for string
      return id.Concat(length).Concat(bytes).ToArray();
    }

    public static byte[] SerializeValue(bool value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      byte[] length = BitConverter.GetBytes(bytes.Length);
      byte[] id = BitConverter.GetBytes(4); // ID for bool
      return id.Concat(length).Concat(bytes).ToArray();
    }

    public static byte[] SerializeValue(byte[] value)
    {
      byte[] length = BitConverter.GetBytes(value.Length);
      byte[] id = BitConverter.GetBytes(5); // ID for byte[]
      return id.Concat(length).Concat(value).ToArray();
    }

    public static byte[] SerializeValue(ushort value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      byte[] length = BitConverter.GetBytes(bytes.Length);
      byte[] id = BitConverter.GetBytes(6); // ID for ushort
      return id.Concat(length).Concat(bytes).ToArray();
    }

    // Deserialize method for general object types, including records
    public static T Deserialize<T>(byte[] byteArray) where T : notnull
    {
      T obj = default!;
      int index = 0;

      var type = typeof(T);
      var properties = type.GetProperties();

      // For records, we need to use the constructor parameters
      var constructors = type.GetConstructors();
      var constructor = constructors.FirstOrDefault(); // Get the primary constructor
      if (constructor == null) throw new InvalidOperationException("No constructor found for this type.");

      // Get the parameters of the constructor (the constructor's parameters match the record's properties)
      var constructorParameters = constructor.GetParameters();

      var values = new object[constructorParameters.Length];
      int paramIndex = 0;

      while (index < byteArray.Length)
      {
        int propertyId = BitConverter.ToInt32(byteArray, index);
        index += sizeof(int); // Move past ID

        int length = BitConverter.ToInt32(byteArray, index);
        index += sizeof(int); // Move past length

        // Deserialize the property value based on the propertyId (type)
        values[paramIndex] = DeserializeProperty(propertyId, byteArray.Skip(index).Take(length).ToArray());
        paramIndex++;

        index += length; // Move to the next property
      }

      // Now, create the object using the constructor with the deserialized values
      obj = (T)constructor.Invoke(values);

      return obj;
    }

    // Deserialize the property value based on its ID
    private static object DeserializeProperty(int propertyId, byte[] propertyBytes)
    {
      switch (propertyId)
      {
        case 0:
          return BitConverter.ToInt32(propertyBytes, 0); // Deserialize int
        case 1:
          return BitConverter.ToSingle(propertyBytes, 0); // Deserialize float
        case 2:
          return BitConverter.ToDouble(propertyBytes, 0); // Deserialize double
        case 3:
          return Encoding.UTF32.GetString(propertyBytes); // Deserialize string
        case 4:
          return BitConverter.ToBoolean(propertyBytes, 0); // Deserialize bool
        case 5:
          return new IPAddress(propertyBytes); // Deserialize byte[] directly
        case 6:
          return BitConverter.ToUInt16(propertyBytes, 0); // Deserialize ushort
        default:  
          throw new InvalidOperationException($"Unsupported property ID: {propertyId}");
      }
    }
  }
}
