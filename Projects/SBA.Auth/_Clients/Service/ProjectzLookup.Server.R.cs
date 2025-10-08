using GLOB.API.Extz;
using Grpc.Core;
using SBA.Projectz.Grpc.Base;
using SBA.Projectz.Grpc.Model;

namespace SBA.Projectz.Grpc.Service;

public partial class ProjectzLookupServer
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
}