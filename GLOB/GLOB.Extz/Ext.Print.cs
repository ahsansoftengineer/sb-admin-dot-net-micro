namespace GLOB.Extz;

public static partial class Exts
{
  public static void Print(this object obj, string? heading = null)
  {
    try
    {
      string result = JsonConvert.SerializeObject(obj, Formatting.Indented);
      result = result.Replace("\"", "");
      Console.WriteLine("➡️ [{0}] \n{1}", heading ?? "Object", result);
    }
    catch (Exception ex)
    {
      ex.Print("💀  ENV Parse Failed  💥");
    }
  }
  public static void Print(this Exception ex, string? heading = null)
  {
    ex.Source.Print($"💀  {heading ?? "Kaboom"}  💥");
    ex.Message.Print($"💀  {heading ?? "Msg"}  💥");
  }
  public static void Print(this string value, string? heading = null)
  {
    Console.WriteLine("➡️  [{0}]\t\t{1}\n", heading ?? "Message", value);
  }
  public static void Print()
  {
    Console.WriteLine("🔥  ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━  💀   Error  ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━  🔥");
  }

}