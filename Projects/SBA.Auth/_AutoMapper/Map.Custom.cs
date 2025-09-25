using GLOB.API.Mapper;
using GLOB.Domain.Model.Auth;
using SBA.Auth.Grpc;

namespace SBA.Projectz.Mapper;

public partial class ProjectzMapper : API_Base_Mapper
{
  public ProjectzMapper() : base()
  {
  }
  public override void MapCustom()
  {
    base.MapCustom();
    MapCRUD<InfraUser, InfraUserDtoCreate, InfraUserDtoUpdate, InfraUserDtoRead, InfraUserDtoSearch, DtoSelect>();
    MapGrpc();
    // MapCRUD<Systemz, SystemzDto, SystemzDtoCreate, SystemzDtoSearch>();
  }
}