using GLOB.API.Config.Optionz;
using SBA.Projectz.Grpc.Service;

namespace SBA.Projectz.DI;

public static partial class DI_Projectz
{
  public static void Use_Projectz_Clientz_Grpc(this IEndpointRouteBuilder route, Option_App appConfig)
  {
    route.MapGrpcService<GrpcProjectzLookupservice>();
    route.MapGet($"{appConfig.ASPNETCORE_ROUTE_PREFIX}/protos/projectz-lookup.proto", async ctx =>
    {
      var path = "_Clients/Protos/projectzLookup.jackson.proto";

      if (File.Exists(path))
      {
        var content = File.ReadAllText(path);
        await ctx.Response.WriteAsync(content);
      }
      else
      {
        ctx.Response.StatusCode = StatusCodes.Status404NotFound;
        await ctx.Response.WriteAsync($"File not found: {path}");
      }
    });
  }
  public static void Add_Projectz_Clientz_Grpc(this IServiceCollection srvc)
  {
    srvc.AddGrpc();
  }
}

