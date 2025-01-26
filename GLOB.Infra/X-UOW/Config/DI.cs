using Microsoft.EntityFrameworkCore;

namespace ProjectName.Infra.Config
{
  public static class DI
  {
    public static ModelBuilder AddInitialEntityData(this ModelBuilder builder)
    {
      builder.ApplyConfiguration(new RoleConfig());
      builder.ApplyConfiguration(new CommonConfigz<Org>());
      builder.ApplyConfiguration(new CommonStatusConfigz<DonorType>());
      builder.ApplyConfiguration(new SystemzConfig());
      return builder;
    }
  }
}