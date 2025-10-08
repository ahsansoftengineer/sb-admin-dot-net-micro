using Google.Protobuf.WellKnownTypes;


namespace GLOB.API.Extz;

public static partial class Exts
{
  public static Struct ToProtoStruct(this object? obj)
  {
    if (obj == null)
      return new Struct();

    try
    {
      var json = JsonConvert.SerializeObject(obj);
      return Struct.Parser.ParseJson(json);
    }
    catch
    {
      return new Struct();
    }
  }
}