// // using GLOB.API.Clientz;

// using GLOB.Infra.Utils.Attributez;

using SBA.Projectz.Grpc.Base;

namespace SBA.Auth.Controllers;

public partial class __GrpcClientController
{
  [HttpPost]
  public async Task<IActionResult> Gets()
  {
        var req = new GrpcReq();
        var res = await projectzLookupClient.GetsAsync(req);
        return res.Pro;
    // return result.Records.ToExtVMList().Ok();
    return null;
  }
  // Single, Include
  [HttpPost("{Id:int}")]
  public async Task<IActionResult> Get(int Id, [FromBody] DtoRequestGet req)
  {
    // var result = await API_Httpz_AuthLookup.Get<ResponseRecord<ProjectzLookup>>(new()
    // {
    //   Resource = Id.ToString(),
    //   Body = new { Includes = req?.Includes ?? null }
    // });
    // return result.Record.ToExtVMSingle().Ok();
    return null;
  }
}