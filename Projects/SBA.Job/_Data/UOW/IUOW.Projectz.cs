using GLOB.Hierarchy.Global;
using GLOB.Infra.Repo;
namespace SBA.Projectz.Data;
public interface IUOW_Projectz : IUOW_Infra
{
  // .-*
  IRepoGenericz<GlobalLookupBase> GlobalLookupBases { get; }

  // *-.
  IRepoGenericz<GlobalLookup> GlobalLookups { get; }
}