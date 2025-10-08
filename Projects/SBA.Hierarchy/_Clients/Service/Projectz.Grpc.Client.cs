using GLOB.API.Config.Optionz;
using Microsoft.Extensions.Options;

namespace SBA.Projectz.Grpc.Service;

public partial class ProjectzGrpcClient
{
  private readonly Option_Host option_Grpc;

  public readonly AuthGrpcClient? auth;

  public ProjectzGrpcClient(IOptions<Option_App> optionApp)
  {
    option_Grpc = optionApp.Value.Clients.Grpc;

    auth = new AuthGrpcClient(option_Grpc.Auth);
  }
}