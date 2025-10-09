using GLOB.Hierarchy.Global;
using GLOB.Infra.Repo;
namespace SBA.Projectz.Data;
public partial class UOW_Projectz : UOW_Infra, IUOW_Projectz
{
  public UOW_Projectz(DBCtxProjectz context) : base(context) { }
  // .-*
  private IRepoGenericz<GlobalLookupBase>? _GlobalLookupBase;

  // *-.
  private IRepoGenericz<GlobalLookup>? _GlobalLookup;
}