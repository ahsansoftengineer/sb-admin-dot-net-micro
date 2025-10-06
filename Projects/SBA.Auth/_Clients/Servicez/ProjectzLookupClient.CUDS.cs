// namespace SBA.Projectz.Grpc.Service;

// public partial class ProjectzLookupClient
// {
//   public override async Task<BaseGrpcRes> Create(BaseGrpcCreate request, ServerCallContext context)
//   {
//     var entity = new ProjectzLookup
//     {
//       Name = request.Name,
//       Status = (Status)request.Status,
//       Desc = request.Desc
//     };

//     await _uow.ProjectzLookups.Add(entity);
//     await _uow.Save();

//     return new BaseGrpcRes { Status = 1, Message = "Created successfully" };
//   }

//   public override async Task<BaseGrpcRes> Update(BaseGrpcUpdate request, ServerCallContext context)
//   {
//     var entity = await _uow.ProjectzLookups.Get(request.Id);
//     entity.Name = request.Name;
//     entity.Status = (Status)request.Status;
//     entity.Desc = request.Desc;

//     _uow.ProjectzLookups.Update(entity);
//     await _uow.Save();

//     return new BaseGrpcRes { Status = 1, Message = "Updated successfully" };
//   }

//   public override async Task<BaseGrpcRes> Delete(BaseGrpcById request, ServerCallContext context)
//   {
//     await _uow.ProjectzLookups.Delete(request.Id);
//     await _uow.Save();

//     return new BaseGrpcRes { Status = 1, Message = "Deleted successfully" };
//   }

// }