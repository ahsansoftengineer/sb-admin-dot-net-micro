namespace GLOB.API.Config.Optionz;
public class Option_KestrelConfig
{
  public Option_KestrelEndpoints Endpoints { get; set; }
}

public class Option_KestrelEndpoints
{
  public Option_KestrelEndpoint Http { get; set; }
  public Option_KestrelEndpoint Https { get; set; }
}

public class Option_KestrelEndpoint
{
  public string Url { get; set; }
  public string Protocols { get; set; }
  public Option_KestrelCertificate Certificate { get; set; }
}

public class Option_KestrelCertificate
{
  public string Path { get; set; }
  public string Password { get; set; }
}