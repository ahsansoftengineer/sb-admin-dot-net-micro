using SBA.Projectz.Grpc.Base;

namespace SBA.Projectz.Grpc.Service;

public partial class ProjectzLookupClient
{
  public async Task<GrpcRes> CreateAsync(GrpcDtoCreate dto)
  {
    return await _client.CreateAsync(dto);
  }

  public async Task<GrpcRes> UpdateAsync(GrpcDtoUpdate dto)
  {
    return await _client.UpdateAsync(dto);
  }

  public async Task<GrpcRes> UpdateStatusAsync(GrpcDtoUpdateStatus dto)
  {
    return await _client.UpdateStatusAsync(dto);
  }

  public async Task<GrpcRes> DeleteAsync(GrpcReqById dto)
  {
    return await _client.DeleteAsync(dto);
  }
}