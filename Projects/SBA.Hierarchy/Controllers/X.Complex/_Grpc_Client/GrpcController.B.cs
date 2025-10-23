using SBA.Projectz.Grpc.Service;

namespace SBA.Auth.Controllers;

public partial class __GrpcController : API_1_InjectorController<__GrpcController>
{
  private readonly UOW_Projectz_Grpc uowGrpc;
  public __GrpcController(IServiceProvider sp) : base(sp)
  {
    uowGrpc = sp.GetSrvc<UOW_Projectz_Grpc>();
  }
}