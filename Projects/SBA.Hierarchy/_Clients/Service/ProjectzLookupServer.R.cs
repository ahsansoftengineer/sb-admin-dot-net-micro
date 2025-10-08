using SBA.Projectz.Grpc.Base;

namespace SBA.Projectz.Grpc.Service;

public partial class ProjectzLookupClient
{
  public async Task<IEnumerable<object>> GetsAsync()
  {
    var req = new GrpcReq();
    var res = await _client.GetsAsync(req);
    return res.ProjectzLookups;
  }

  public async Task<object?> GetAsync(int id)
  {
    var req = new GrpcReqById { Id = id };
    var res = await _client.GetAsync(req);
    return res.ProjectzLookup;
  }
}