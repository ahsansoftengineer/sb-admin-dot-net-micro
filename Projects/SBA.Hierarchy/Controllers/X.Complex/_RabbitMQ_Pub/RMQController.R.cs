namespace SBA.Auth.Controllers;

public partial class __RMQController
{
  [HttpPost]
  public async Task<IActionResult> Gets()
  {
    // var result = await API_Httpz_AuthLookup.Gets<ResponseRecords<ProjectzLookup>>(new()
    // {
    //   Body = new { includes = new List<string>() { "ProjectzLookupBase" } }
    // });
    // return result.Records.ToExtVMList().Ok();
    return new[] { new { Message = "Not Yet Implemented" } }.ToExtVMList().Ok();
  }
  // Single, Include
  [HttpPost("{Id:int}")]
  public async Task<IActionResult> Get(int Id)
  {
    // var result = await API_Httpz_AuthLookup.Get<ResponseRecord<ProjectzLookup>>(new()
    // {
    //   Resource = Id.ToString(),
    //   Body = new { Includes = req?.Includes ?? null }
    // });
    // return result.Record.ToExtVMSingle().Ok();
    return new { Message = "Not Yet Implemented" }.ToExtVMSingle().Ok();
  }
}