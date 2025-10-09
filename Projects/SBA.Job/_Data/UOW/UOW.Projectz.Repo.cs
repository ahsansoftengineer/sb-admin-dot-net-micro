using GLOB.Hierarchy.Global;
using GLOB.Infra.Repo;

namespace SBA.Projectz.Data;
public partial class UOW_Projectz
{
  // .-*
  public IRepoGenericz<GlobalLookupBase> GlobalLookupBases => _GlobalLookupBase ??= new RepoGenericz<GlobalLookupBase>(_context);

  // *-.
  public IRepoGenericz<GlobalLookup> GlobalLookups => _GlobalLookup ??= new RepoGenericz<GlobalLookup>(_context);
}