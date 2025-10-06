using AutoMapper;
using Microsoft.Extensions.Options;

namespace SBA.Projectz.Grpc.Service;

public partial class ProjectzLookupClient : GrpcProjectzLookup.GrpcProjectzLookupClient
{
  private readonly IMapper _map;
  private readonly IUOW_Projectz _uow;
  private readonly Option_Host _Option_Host;

  public ProjectzLookupClient(IServiceProvider sp)
  {
    _map = sp.GetSrvc<IMapper>();
    _Option_Host = sp.GetSrvc<IOptions<Option_App>>().Value.Clients.Grpc;
    _uow = sp.GetSrvc<IUOW_Projectz>();

  }
}