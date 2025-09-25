using GLOB.API.Clientz;
using SBA.Projectz.Clientz;

namespace SBA.Projectz.DI;

public static partial class DI_Projectz
{
  public static void Add_Projectz_Clientz(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.AddSingleton<UOW_API_Httpz>();
    srvc.Add_Projectz_RMQ(config);
    srvc.Add_Projectz_Grpc(config);
  }
  public static void Add_Projectz_RMQ(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Add_API_RabbitMQ(config);
    // srvc.AddSingleton<MsgBusPub>();
    // srvc.AddSingleton<Projectz_RMQ_Pub>();
    srvc.AddSingleton<Projectz_RMQ_Sub>();
    srvc.AddHostedService<MsgBusSubs>(); // Jackson
    srvc.AddHostedService<RMQ_Sub_Lookup_Create>();
    srvc.AddHostedService<RMQ_Sub_Lookup_Delete>();
    srvc.AddHostedService<RMQ_Sub_Lookup_Status>();
    srvc.AddHostedService<RMQ_Sub_Lookup_Update>();
  }
  public static void Add_Projectz_Grpc(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.AddGrpc();
  }
}
