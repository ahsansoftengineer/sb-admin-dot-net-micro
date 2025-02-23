using GLOB.Apps.Common;
using GLOB.Domain.Hierarchy;
using GLOB.Infra.Repo;
using GLOB.Infra.UOW;

namespace SBA.Hierarchy.Data;
public partial class UOW : UnitOfWorkz, IUOW
{
  public UOW(AppDBContextProj context): base(context) { }
  private IRepoGenericz<TestProj>? _testProj;
  // .-*
  private IRepoGenericz<Org>? _Orgs;
  private IRepoGenericz<BG>? _BG;
  private IRepoGenericz<State>? _State;
  private IRepoGenericz<Bank>? _Bank;
  private IRepoGenericz<Brand>? _Brand;
  private IRepoGenericz<Industry>? _Industry;
  private IRepoGenericz<Profession>? _Profession;
  
  // *-.
  private IRepoGenericz<Systemz>? _Systemz;
  private IRepoGenericz<LE>? _LE;
  private IRepoGenericz<OU>? _OU;
  private IRepoGenericz<SU>? _SU;
  private IRepoGenericz<City>? _City;

    
}