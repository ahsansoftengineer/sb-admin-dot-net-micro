
using GLOB.API.DI;
using GLOB.Infra.Context;
using GLOB.Infra.UOW;

namespace GLOB.API;
// Note: Servicies are required when not in Micro Arch
// Current IOC Containers of Child Are being Used
public class Startup
{
  public IConfiguration _config { get; }

  public Startup(IConfiguration config)
  {
    _config = config;
  }
  public void ConfigureServices(IServiceCollection srvc)
  {
    // srvc.AddDICommon();
    // srvc.Config_DB_SQL<DBCntxt, IUnitOfWorkz, UnitOfWorkz>(_config);
    // srvc.Config_DB_Identity<DBCntxtIdentity, IUnitOfWorkz, UnitOfWorkz>(_config);
    // srvc.AddAutoMapper(typeof(MapBase));
    // srvc.AddDefaultExternalServices();
  }
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    // app.AddDefaultExternalConfiguration(env);
    // app.UseCors("CorsPolicyAllowAll");
   
    // app.UseHttpsRedirection();
    // if(!env.IsDevelopment()){
    //   app.Seed();
    // }
  }
}
