using GLOB.Apps.Common;
using GLOB.Domain.Hierarchy;

namespace SBA.Hierarchy.Data;
public interface IUOW : IUnitOfWorkz
{
  IRepoGenericz<TestProj> TestProjs { get; }
  // .-*
  IRepoGenericz<Org> Orgs { get; }
  IRepoGenericz<BG> BGs { get; }
  IRepoGenericz<State> States { get; }
  IRepoGenericz<Bank> Banks { get; }
  IRepoGenericz<Brand> Brands { get; }
  IRepoGenericz<Industry> Industrys { get; }
  IRepoGenericz<Profession> Professions { get; }


  // *-.
  IRepoGenericz<Systemz> Systemzs { get; }
  IRepoGenericz<LE> LEs { get; }
  IRepoGenericz<OU> OUs { get; }
  IRepoGenericz<SU> SUs { get; }
  IRepoGenericz<City> Citys { get; }
}