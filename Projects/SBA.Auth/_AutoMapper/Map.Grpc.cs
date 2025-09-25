using GLOB.API.Mapper;
using GLOB.Domain.Model.Auth;
using SBA.Auth.Grpc;

namespace SBA.Projectz.Mapper;

public partial class ProjectzMapper : API_Base_Mapper
{
  private void MapGrpc()
  {
    // CreateMap<ProjectzLookup, GrpcLookupModel>()
    //  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
    //  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
    //  .ForMember(dest => dest.Desc, opt => opt.MapFrom(src => src.Desc))
    //  .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
      // .ForMember(dest => dest.ProjectzLookupBaseId, opt => opt.MapFrom(src => src.ProjectzLookupBaseId));
  }
}