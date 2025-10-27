using AutoMapper;
using Microsoft.Extensions.Options;
using SBA.Projectz.Grpc.Model;

namespace SBA.Projectz.Grpc.Service;

public partial class ProjectzLookupServer : GrpcProjectzLookup.GrpcProjectzLookupBase
{
  private readonly IMapper _map;
  private readonly IUOW_Projectz _uow;
  private readonly Option_Client _Option_Client;

  public ProjectzLookupServer(IServiceProvider sp)
  {
    _map = sp.GetSrvc<IMapper>();
    _Option_Client = sp.GetSrvc<IOptions<Option_App>>().Value.Clients.Grpc;
    _uow = sp.GetSrvc<IUOW_Projectz>();

  }
}