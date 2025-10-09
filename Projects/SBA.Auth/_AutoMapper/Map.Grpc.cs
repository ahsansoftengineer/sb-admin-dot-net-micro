using GLOB.API.Mapper;
using SBA.Projectz.Grpc.Base;

namespace SBA.Projectz.Mapper;

public partial class ProjectzMapper : API_Base_Mapper
{
  private void MapGrpc()
  {
    CreateMap<ProjectzLookup, GrpcDtoUpdate>();
    //  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
  }
}