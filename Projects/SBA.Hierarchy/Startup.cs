using Microsoft.Extensions.Options;

namespace SBA.Hierarchy;
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
    app.Use_API_Default_Middlewares();
    app.Use_API_Config_Controller((route) =>
    {
      route.Use_Projectz_Clientz_Grpc(appConfig);
    });

    app.SeedProjectz();
  }
}