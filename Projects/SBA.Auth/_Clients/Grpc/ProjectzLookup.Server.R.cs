using Grpc.Core;
using SBA.Projectz.Grpc.Base;
using SBA.Projectz.Grpc.Model;

namespace SBA.Projectz.Grpc.Service;

public partial class ProjectzLookupServer
{
  public async override Task<GrpcResProjectzLookups> Gets(GrpcReqEmpty request, ServerCallContext context)
  {
    var data = await _uow.ProjectzLookups.Gets();

    if (data == null || !data.Any()) return new GrpcResProjectzLookups();

    var response = new GrpcResProjectzLookups();

    response.ProjectzLookups.AddRange(data.Select(_map.Map<GrpcDtoUpdate>));
    return response;
  }

  public override async Task<GrpcResProjectzLookup> Get(GrpcReqById request, ServerCallContext context)
  {
    var entity = await _uow.ProjectzLookups.Get(request.Id);
    if (entity == null) return new GrpcResProjectzLookup();

    var result = _map.Map<GrpcDtoUpdate>(entity);
    return new GrpcResProjectzLookup
    {
      ProjectzLookup = new GrpcDtoUpdate
      {
        Id = result.Id,
        Name = result.Name,
        Desc = result.Desc,
        Status = result.Status,
        ProjectzLookupBaseId = result.ProjectzLookupBaseId,
      }
    };
  }
}
// ProjectzLookup = entity.ToProtoStruct()