using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;
public partial class AccountController : AlphaController<AccountController>
{
  [HttpPost("enable-2fa")]
  [Authorize]
  public async Task<IActionResult> Enable2FA()
  {
    return null;
  }

  [HttpPost("verify-2fa")]
  public async Task<IActionResult> Verify2FA([FromBody] TwoFactorDto model)

  {
    return null;
  }
  [HttpPost("disable-2fa")]
  [Authorize]
  public async Task<IActionResult> Disable2FA()
  {
    return null;
  }

}