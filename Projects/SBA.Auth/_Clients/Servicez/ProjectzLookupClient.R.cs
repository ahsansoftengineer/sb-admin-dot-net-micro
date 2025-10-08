using GLOB.API.Extz;
using Grpc.Core;
using SBA.Projectz.Grpc.Base;
using SBA.Projectz.Grpc.Model;

namespace SBA.Projectz.Grpc.Service;

public partial class ProjectzLookupClient : GrpcProjectzLookup.GrpcProjectzLookupBase
{
  public async override Task<GrpcResProjectzLookups> Gets(GrpcReq request, ServerCallContext context)
  {
    var data = await _uow.ProjectzLookups.Gets();

    if (data == null || !data.Any()) return new GrpcResProjectzLookups(); 

    var response = new GrpcResProjectzLookups();
    response.ProjectzLookups.AddRange(data.Select(d => d.ToProtoStruct()));
    return response;
  }

  public override async Task<GrpcResProjectzLookup> Get(GrpcReqById request, ServerCallContext context)
  {
    var entity = await _uow.ProjectzLookups.Get(request.Id);
    if (entity == null) return new GrpcResProjectzLookup();


    return new GrpcResProjectzLookup
    {
      ProjectzLookup = entity.ToProtoStruct()
    };
  }
  // public IEnumerable<ProjectzLookup> Gets()
  // {
  //   $"Calling Grpc Service {_Option_Host.Auth}".Print("Grpc");

  //   var channel = GrpcChannel.ForAddress(_Option_Host.Auth, new GrpcChannelOptions
  //   {
  //   Credentials = ChannelCredentials.Insecure
  //   });

  //   var client = new GrpcProjectzLookup.GrpcProjectzLookupClient(channel);
  //   var req = new GetAllRequest();

  //   try
  //   {
  //   var res = client.Gets(req);
  //   return _map.Map<IEnumerable<ProjectzLookup>>(res.ProjectzLookups);
  //   }
  //   catch (Exception ex)
  //   {
  //   ex.Print("Grpc Error");
  //   return null;
  //   }
  // }

}