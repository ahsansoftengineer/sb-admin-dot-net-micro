using GLOB.API.Extz;
using SBA.Projectz.Grpc.Service;

namespace SBA.Projectz.DI;

public static partial class DI_Projectz
{
  public static void Use_Projectz_Clientz_Grpc(this IEndpointRouteBuilder route, Option_App appConfig)
  {
    string prefix = appConfig.ASPNETCORE_ROUTE_PREFIX + "/protos/";
    route.MapFileToRoute($"{prefix}base.proto", "_Clients/Protos/base.proto");

    route.MapGrpcService<ProjectzLookupServer>();
    route.MapFileToRoute($"{prefix}projectzlookup.proto", "_Clients/Protos/projectzlookup.proto");
  }
  public static void Add_Projectz_Clientz_Grpc(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.AddGrpc();
  }
}

