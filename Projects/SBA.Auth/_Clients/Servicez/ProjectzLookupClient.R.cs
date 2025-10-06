// using Grpc.Core;
// using Grpc.Net.Client;

// namespace SBA.Projectz.Grpc.Service;

// public partial class ProjectzLookupClient
// {
  
//   public override async Task<BaseGrpcProjectzLookups> Gets(BaseGrpcGets request, ServerCallContext context)
//   {
//     var data = await _uow.ProjectzLookups.Gets();
//     var response = new BaseGrpcProjectzLookups();
//     response.ProjectzLookups.AddRange(data.Select(d => new BaseGrpcUpdate
//     {
//       Id = d.Id,
//       Name = d.Name,
//       Status = (BaseGrpcStatus)d.Status,
//       Desc = d.Desc
//     }));
//     return response;
//   }

//   public override async Task<BaseGrpcProjectzLookup> Get(BaseGrpcById request, ServerCallContext context)
//   {
//     var entity = await _uow.ProjectzLookups.Get(request.Id);
//     return new BaseGrpcProjectzLookup
//     {
//       ProjectzLookup = new BaseGrpcUpdate
//       {
//         Id = entity.Id,
//         Name = entity.Name,
//         Status = (BaseGrpcStatus)entity.Status,
//         Desc = entity.Desc
//       }
//     };
//   }
//   // public IEnumerable<ProjectzLookup> Gets()
//   // {
//   //   $"Calling Grpc Service {_Option_Host.Auth}".Print("Grpc");

//   //   var channel = GrpcChannel.ForAddress(_Option_Host.Auth, new GrpcChannelOptions
//   //   {
//   //     Credentials = ChannelCredentials.Insecure
//   //   });

//   //   var client = new GrpcProjectzLookup.GrpcProjectzLookupClient(channel);
//   //   var req = new GetAllRequest();

//   //   try
//   //   {
//   //     var res = client.Gets(req);
//   //     return _map.Map<IEnumerable<ProjectzLookup>>(res.ProjectzLookups);
//   //   }
//   //   catch (Exception ex)
//   //   {
//   //     ex.Print("Grpc Error");
//   //     return null;
//   //   }
//   // }

// }