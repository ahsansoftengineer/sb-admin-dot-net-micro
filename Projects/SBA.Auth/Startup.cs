using Microsoft.Extensions.Options;
// using SBA.Projectz.Grpc.Service;

namespace SBA.Auth;
public class Startup
{
  private IConfiguration _config { get; }

  public Startup(IConfiguration config)
  {
    _config = config;
  }

  public void ConfigureServices(IServiceCollection srvc)
  {
    srvc.Add_Projectz_Srvc(_config);
  }
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    Option_App appConfig = app.GetSrvc<IOptions<Option_App>>().Value;
    appConfig.Print("ENV");

    app.Use_API_Default_Middlewares((route) =>
    {
      route.Use_Projectz_Clientz_Grpc(appConfig);
    });
    app.SeedProjectz().GetAwaiter().GetResult();
  }


}