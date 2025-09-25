using Microsoft.Extensions.Options;
using SBA._Clients.Service;

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
      route.MapGrpcService<GrpcProjectzLookupService>();
      route.MapGet($"{appConfig.ASPNETCORE_ROUTE_PREFIX}/protos/projectz-lookup.proto", async ctx =>
      {
        var path = "_Clients/Protos/projectzLookup.jackson.proto";

        if (File.Exists(path))
        {
            var content = File.ReadAllText(path);
            await ctx.Response.WriteAsync(content);
        }
        else
        {
            ctx.Response.StatusCode = StatusCodes.Status404NotFound;
            await ctx.Response.WriteAsync($"File not found: {path}");
        }
      });
    });
    app.SeedProjectz().GetAwaiter().GetResult();
  }
}