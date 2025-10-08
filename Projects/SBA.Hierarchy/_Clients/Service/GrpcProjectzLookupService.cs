// using AutoMapper;
// using Grpc.Core;

// namespace SBA.Projectz.Grpc.Service;

// public class GrpcProjectzLookupservice : GrpcProjectzLookup.GrpcProjectzLookupBase
// {
//   private readonly IUOW_Projectz _uowProjectz;
//   private readonly IMapper _map;

//   public GrpcProjectzLookupservice(IServiceProvider sp)
//   {
//     _uowProjectz = sp.GetSrvc<IUOW_Projectz>();
//     _map = sp.GetSrvc<IMapper>();
//   }

//   public override async Task<ProjectzLookupRes> Gets(GetAllRequest req, ServerCallContext context)
//   {
//     var res = new ProjectzLookupRes();
//     var entities = await _uowProjectz.ProjectzLookups.Gets();

//     foreach (var entity in entities)
//     {
//       var item = _map.Map<GrpcProjectzLookupModel>(entity);
//       res.ProjectzLookups.Add(item);
//     }
//     return await Task.FromResult(res);
//   }

// }