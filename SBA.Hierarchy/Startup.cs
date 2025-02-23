using GLOB.API.DI;
using GLOB.API.Mapper;
using SBA.Projectz.Data;
using SBA.Projectz.DI;
using SBA.Projectz.Mapper;

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
    
    srvc.AddDICommon();
    srvc.AddAutoMapper(typeof(MapAllProj));
    srvc.AddSrvc(_config);
    srvc.AddDefaultExternalServices();

  }
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    app.AddDefaultExternalConfiguration(env);
    Console.WriteLine($"Current Environment: {env.EnvironmentName}");
    if(!env.IsDevelopment()){
      app.Seed();
    }
  }
}