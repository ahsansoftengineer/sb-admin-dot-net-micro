using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Seed;

namespace SBA.Hierarchy.Common;
public static partial class Seeder
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    Console.WriteLine("--> Hierarchy -> Applying Migrations ModelBuilder");
    // mb.SeedTestInfra();
    mb.SeedTestProj();
    // .-*
    mb.SeedOrg();
    mb.SeedBG();

    // *-.
    mb.SeedSystemz();
    mb.SeedLE();
    mb.SeedOU();
    mb.SeedSU();

  }
  // Prod (When Running Migration throw Automation)
  public static void Seed(this IApplicationBuilder app)
  {
    using (var srvcScp = app.ApplicationServices.CreateScope())
    {
      AppDBContextProj? context = srvcScp.ServiceProvider.GetService<AppDBContextProj>();
      if (context != null)
      {
        Console.WriteLine("--> Hierarchy -> Applying Migrations AppBuilder");
        context.Database.Migrate();
        {
          // context.SeedTestInfra();
          context.SeedTestProj();
          context.SeedOrg();
          context.SeedSystemz();
          context.SeedBG();
          context.SeedLE();
          context.SeedOU();
          context.SeedSU();
        }
      }
    }
  }

}