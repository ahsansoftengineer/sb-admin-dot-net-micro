using GLOB.API.Config.Optionz;
using Microsoft.Extensions.Options;

namespace SBA.Projectz.Grpc.Service;

public partial class UOW_Projectz_Grpc
{
  private readonly Option_Host option_Grpc;

  public readonly AuthGrpcClient? auth;

  public UOW_Projectz_Grpc(IOptions<Option_App> optionApp)
  {
    option_Grpc = optionApp.Value.Clients.Grpc;
    option_Grpc.Print("GRPC");
    
    auth = new AuthGrpcClient(option_Grpc.Auth);
  }
}