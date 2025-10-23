using SBA.Projectz.Clientz;

namespace SBA.Auth.Controllers;

public partial class __RMQController : API_1_InjectorController<__RMQController>
{
  private readonly Projectz_RMQ_Pub _rmqPub;
  public __RMQController(IServiceProvider sp) : base(sp)
  {
    _rmqPub = sp.GetSrvc<Projectz_RMQ_Pub>();
  }
}