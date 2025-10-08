using SBA.Projectz.Grpc.Service;

namespace SBA.Auth.Controllers;

public partial class __GrpcClientController : API_1_InjectorController<__GrpcClientController>
{
  private readonly ProjectzLookupClient projectzLookupClient;
  public __GrpcClientController(IServiceProvider sp) : base(sp)
  {
    projectzLookupClient = sp.GetSrvc<ProjectzLookupClient>();
  }

//   [HttpPost] [NoCache]
//   public async Task<IActionResult> Add([FromBody] ProjectzLookupDtoCreate model)
//   {
//     try
//     {
//       var data = new
//       {
//         model.Name,
//         model.Code,
//         model.Desc,
//         model.ProjectzLookupBaseId,
//         Status.Active,
//         Event = $"ProjectzLookup_{EP.Add}"
//       };
//       MsgBusJackson.Publish(data);
//       return data.ToExtVMSingle().Ok();
//     }
//     catch (Exception ex)
//     {
//       // return ex.Ok();
//       return $"[Rabbit MQ] Error : {ex.Message}".ToExtVMSingle().Ok();
//     }
//   }
}