using GLOB.Infra.Repo;
using GLOB.Domain.Projectz;
using GLOB.Infra.UOW;

namespace SBA.Projectz.Data;
public interface IUOW : IUnitOfWorkz
{
  IRepoGenericz<TestProj> TestProjs { get; }
}