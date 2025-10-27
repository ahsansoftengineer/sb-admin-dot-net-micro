// Need to Work on That Service for Always

using Microsoft.Extensions.Options;

namespace GLOB.API.Clientz;

public partial class UOW_API_Httpz
{
  private readonly IServiceProvider _sp;
  private readonly Option_Client _Option_Client;
  private API_Client_Http _ClientHttpAuth;

  public UOW_API_Httpz(IServiceProvider sp)
  {
    _sp = sp;
    _Option_Client = sp.GetSrvc<IOptions<Option_App>>().Value.Clients.Httpz;
  }

  public API_Client_Http ClientHttpAuth => _ClientHttpAuth ??= new API_Client_Http(_sp, _Option_Client.Auth, PrefixHttp.Auth, Controllerz.Auth.ProjectzLookup);
}