using GLOB.API.Clientz;
using SBA.Projectz.Clientz;

namespace SBA.Projectz.DI;

public static partial class DI_Projectz
{
  public static void Add_Projectz_Clientz(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.AddSingleton<UOW_API_Httpz>();
    srvc.Add_Projectz_Clientz_RMQ(config);
    srvc.Add_Projectz_Clientz_Grpc(config);
  }
}
