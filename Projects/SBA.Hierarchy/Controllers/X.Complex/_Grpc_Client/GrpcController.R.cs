namespace SBA.Auth.Controllers;

public partial class __GrpcClientController
{
  [HttpPost]
  public async Task<IActionResult> Gets()
  {
    var res = await uowGrpc.auth.projectzLookup.GetsAsync(new());
    return res.ProjectzLookups.ToExtVMList().Ok();
  }
  [HttpPost("{Id:int}")]
  public async Task<IActionResult> Get(int Id)
  {
    var res = await uowGrpc.auth.projectzLookup.GetAsync(new () { Id = Id });
    return res.ProjectzLookup.ToExtVMSingle().Ok();
  }
}