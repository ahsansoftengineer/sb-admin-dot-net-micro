using GLOB.API.Mapper;
using GLOB.Domain.Hierarchy;

namespace SBA.Projectz.Mapper;
public class MapCommonProj : MapCommon
{
  public MapCommonProj() : base()
  {
    CreateMapCommon<TestProj>();
    CreateMapCommon<Org>();
    CreateMapCommon<BG>();
    CreateMapCommon<Bank>();
    CreateMapCommon<Brand>();
    CreateMapCommon<Industry>();
    CreateMapCommon<Profession>();
    CreateMapCommon<State>();
  }
}