using GLOB.Apps.Common;
using GLOB.Domain.Base;
using GLOB.Infra.Context;
using GLOB.Infra.Repo;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.UOW;
public partial class UnitOfWorkz : IUnitOfWorkz
{
  public readonly DBCntxt _context;
  public UnitOfWorkz(DBCntxt context)
  {
    _context = context;
  }
  // Hierarchy

  public async Task Save()
  {
    AddTimestamps();
    await _context.SaveChangesAsync();
  }
  // Handling CreatedAt & UpdatedAt
  private void AddTimestamps()
  {
    var entities = _context.ChangeTracker.Entries()
      .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

    foreach (var entity in entities)
    {
      var now = DateTime.UtcNow; // current datetime
      Console.WriteLine(entity.State);
      if (entity.State == EntityState.Added)
      {
        ((BaseEntity)entity.Entity).CreatedAt = now;
      }
    //EntityState.Detached, EntityState.Deleted, EntityState.Unchanged
    ((BaseEntity)entity.Entity).UpdatedAt = now;
    }
  }
  private IRepoGenericz<T> Got<T>() where T : BaseEntity
  {
    return new RepoGenericz<T>(_context);
  }
  public void Dispose()
  {
    _context.Dispose();
    GC.SuppressFinalize(this);
  }
}