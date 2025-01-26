using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GLOB.Domain.Enums;
using GLOB.Domain.Entity;

namespace GLOB.Infra.Common;
public class CommonStatusConfigz<T> : IEntityTypeConfiguration<T>
  where T : BaseStatusEntity, new()
{
  public void Configure(EntityTypeBuilder<T> builder)
  {
    string className = typeof(T).Name;
    builder.HasData(
      new T
      {
        Id = 1,
        Title = className + " 1 Title",
        Desc = className + " 1 Desc",
        Status = Status.None,
      },
      new T
      {
        Id = 2,
        Title = className + " 2 Title",
        Desc = className + " 2 Desc",
        Status = Status.Activate,
      },
      new T
      {
        Id = 3,
        Title = className + " 3 Title",
        Desc = className + " 3 Desc",
        Status = Status.DeActivate,
      }
    );
  }
}