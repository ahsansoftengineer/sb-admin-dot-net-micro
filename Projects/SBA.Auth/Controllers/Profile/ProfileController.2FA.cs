using GLOB.Domain.Model.Auth;

namespace SBA.Auth.Controllers;
public partial class ProfileController
{
  [HttpPost]
  public async Task<IActionResult> MultiFaEnable()
  {
    return null;
  }
  [HttpPost]
  public async Task<IActionResult> MultiFaVerify([FromBody] TwoFactorDto model)
  {
    return null;
  }
  [HttpPost]
  public async Task<IActionResult> MultiFaDisable()
  {
    return null;
  }
}