using GLOB.Domain.Base;
using GLOB.Domain.Projectz;

namespace GLOB.API.Mapper;
public partial class MapBase 
{
  public virtual void MapAll()
  {

    CreateMapAll<TestInfra, DtoRead, DtoCreate, DtoSearch>();
  }
}