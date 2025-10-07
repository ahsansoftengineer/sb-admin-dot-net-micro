using Grpc.Core;
using SBA.Projectz.Grpc.Base;

namespace SBA.Projectz.Grpc.Service;

public partial class ProjectzLookupClient
{
  public override async Task<GrpcRes> Create(GrpcDtoCreate request, ServerCallContext context)
  {
    var entity = new ProjectzLookup
    {
      Name = request.Name,
      Status = (GrpcEnumStatus)request.Status,
      Desc = request.Desc
    };

    await _uow.ProjectzLookups.Add(entity);
    await _uow.Save();

    return new GrpcRes { Status = 200, Message = "Created successfully" };
  }

  public override async Task<GrpcRes> Update(GrpcDtoUpdate request, ServerCallContext context)
  {
    var entity = await _uow.ProjectzLookups.Get(request.Id);
    entity.Name = request.Name;
    entity.Status = (GrpcEnumStatus)request.Status;
    entity.Desc = request.Desc;

    _uow.ProjectzLookups.Update(entity);
    await _uow.Save();

    return new GrpcRes { Status = 200, Message = "Updated successfully" };
  }

  public override async Task<GrpcRes> Delete(GrpcReqById request, ServerCallContext context)
  {
    await _uow.ProjectzLookups.Delete(request.Id);
    await _uow.Save();

    return new GrpcRes { Status = 200, Message = "Deleted successfully" };
  }

}