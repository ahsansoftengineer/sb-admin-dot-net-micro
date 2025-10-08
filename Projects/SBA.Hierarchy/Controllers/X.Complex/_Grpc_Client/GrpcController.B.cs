using SBA.Projectz.Grpc.Service;

namespace SBA.Auth.Controllers;

public partial class __GrpcClientController : API_1_InjectorController<__GrpcClientController>
{
  private readonly UOW_Projectz_Grpc uowGrpc;
  public __GrpcClientController(IServiceProvider sp) : base(sp)
  {
    uowGrpc = sp.GetSrvc<UOW_Projectz_Grpc>();
  }
}