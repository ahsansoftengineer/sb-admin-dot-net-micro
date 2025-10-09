using SBA.Projectz.Clientz;

namespace SBA.Auth.Controllers;

public partial class __RabbitMQController : API_1_InjectorController<__RabbitMQController>
{
  private readonly Projectz_RMQ_Pub _rmqPub;
  public __RabbitMQController(IServiceProvider sp) : base(sp)
  {
    _rmqPub = sp.GetSrvc<Projectz_RMQ_Pub>();
  }
}