using GLOB.Infra.Utils.Attributez;
using SBA.Projectz.Grpc.Base;
namespace SBA.Auth.Controllers;

public partial class __GrpcController
{

  [HttpPost]
  [NoCache]
  public async Task<IActionResult> Create([FromBody] GrpcDtoCreate dto)
  {
    var res = await uowGrpc.auth.projectzLookup.CreateAsync(dto);
    return res.Ok();
  }
  [HttpPut("{Id}")]
  [NoCache]
  public async Task<IActionResult> Update(string Id, [FromBody] GrpcDtoUpdate dto)
  {
    var res = await uowGrpc.auth.projectzLookup.UpdateAsync(dto);
    return res.Ok();
  }

  [HttpDelete("{Id}")]
  [NoCache]
  public async Task<IActionResult> Delete(int Id)
  {
    var res = await uowGrpc.auth.projectzLookup.DeleteAsync(new() { Id = Id });
    return res.Ok();
  }

  [HttpPatch("{Id:int}")]
  [NoCache]
  public async Task<IActionResult> UpdateStatus(int Id, [FromBody] GrpcDtoUpdateStatus dto)
  {
    dto.Id = Id;
    var res = await uowGrpc.auth.projectzLookup.UpdateStatusAsync(dto);
    return res.Ok();

  }
}