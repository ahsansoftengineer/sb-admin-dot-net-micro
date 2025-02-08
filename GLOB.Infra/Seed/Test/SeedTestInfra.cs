using GLOB.Domain.Base;
using GLOB.Domain.Entity;
using GLOB.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class SeederInfra
{
  public static void SeedTestInfra(this AppDBContextz context)
  {
    if (!context.TestInfras.Any(x => x.Id > 0))
    {
      Console.WriteLine("--> Seeding Data TestProj (Context)");
      context.TestInfras.AddRange(SeedDataBaseEntity<TestInfra>());
      context.SaveChanges();
    }
  }
  public static void SeedTestInfra(this ModelBuilder builder)
  {
    Console.WriteLine("--> Seeding Data TestInfra (ModelBuilder)");
    builder.Entity<TestProj>().HasData(SeedDataBaseEntity<TestInfra>());
  }
  public static List<T> SeedDataBaseEntity<T>() where T : BaseEntity, new()
  {
    string className = typeof(T).Name;
    List<T> list = new List<T>();
    for (int i = 0; i < 3; i++)
    {
      list.Add(new T()
      {
        Id = i,
        Title = $"{className} {i}",
        Desc = $"{className} {i} Desc",
      });
    }
    return list;
  }

}