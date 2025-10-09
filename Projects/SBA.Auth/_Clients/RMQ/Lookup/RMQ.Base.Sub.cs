namespace SBA.Projectz.Clientz;

public class RMQ_Base_Sub : BackgroundService
{
  protected Projectz_RMQ_Sub _sub;
  public RMQ_Base_Sub(IServiceProvider sp) : base()
  {
    _sub = sp.GetSrvc<Projectz_RMQ_Sub>();
  }

  protected override async Task ExecuteAsync(CancellationToken token)
  {
    token.ThrowIfCancellationRequested();
    throw new NotImplementedException();
  }
}