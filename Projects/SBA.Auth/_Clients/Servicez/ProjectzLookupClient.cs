using AutoMapper;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Options;

namespace SBA.Projectz.Grpc.Service;

public class ProjectzLookupClient : GrpcProjectzLookup.GrpcProjectzLookupClient
{
  private readonly IMapper _map;
  private readonly Option_Host _Option_Host;

  public ProjectzLookupClient(IServiceProvider sp)
  {
    _map = sp.GetSrvc<IMapper>();
    _Option_Host = sp.GetSrvc<IOptions<Option_App>>().Value.Clients.Grpc;

  }

  public IEnumerable<ProjectzLookup> Gets()
  {
    $"Calling Grpc Service {_Option_Host.Auth}".Print("Grpc");

    var channel = GrpcChannel.ForAddress(_Option_Host.Auth, new GrpcChannelOptions
    {
      Credentials = ChannelCredentials.Insecure
    });
    
    var client = new GrpcProjectzLookup.GrpcProjectzLookupClient(channel);
    var req = new GetAllRequest();

    try
    {
      var res = client.Gets(req);
      return _map.Map<IEnumerable<ProjectzLookup>>(res.ProjectzLookups);
    }
    catch (Exception ex)
    {
      ex.Print("Grpc Error");
      return null;
    }
  }

}