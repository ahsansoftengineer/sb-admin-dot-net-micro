using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Context;

namespace SBA.Hierarchy.Seed;
public static partial class Seeder
{
  public static void SeedOU(this AppDBContextProj context)
  {
    if (!context.OUs.Any(x => x.Id > 0))
    {
      context.OUs.AddRange(SeedDataOU<OU>());
      context.SaveChanges();
    }
  }
  public static void SeedOU(this ModelBuilder builder)
  {
    builder.Entity<OU>().HasData(SeedDataOU<OU>());
  }
  public static List<T> SeedDataOU<T>() where T : OU, new()
  {
    string className = typeof(T).Name;
    List<T> list = new List<T>();
    for (int i = 1; i <= 3; i++)
    {
      list.Add(new T()
      {
        Id = i,
        Title = $"{className} {i}",
        Desc = $"{className} {i} Desc",
        LEId = i,
        Law = className + "Law",
        Address = className + "Address",
        Deposit = className + "Deposit",
        LogoImg = className + "LogoImg",
        TopImg = className + "TopImg",
        WarningImg = className + "WarningImg",
        FooterImg = className + "FooterImg"
      });
    }
    return list;
  }
}