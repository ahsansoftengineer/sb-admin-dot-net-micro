using GLOB.Apps.Common;
using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using GLOB.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GLOB.Infra.Common;
public partial class RepoGenericz<T> : IRepoGenericz<T> where T : BaseEntity
{
  private readonly AppDBContextz _context;
  private readonly DbSet<T> _db;
  public RepoGenericz(AppDBContextz context)
  {
    _context = context;
    _db = context.Set<T>();
  }
  public DbSet<T> GetDBSet()
  {
    return _db;
  }
  public bool Any(Expression<Func<T, bool>>? filter = null)
  {
    return _db.Any(filter);
  }

  public async Task Delete(int id)
  {
    var entity = await _db.FindAsync(id);
    if (entity != null) _db.Remove(entity);
  }

  public void DeleteRange(IEnumerable<T> entities)
  {
    _db.RemoveRange(entities);
  }
  public async Task Insert(T entity)
  {
    await _db.AddAsync(entity);
    //await _context.SaveChangesAsync();
  }

  public async Task InsertRange(IEnumerable<T> entities)
  {
    await _db.AddRangeAsync(entities);
  }

  public void Update(T entity)
  {
    _db.Attach(entity);
    _context.Entry(entity).State = EntityState.Modified;
  }
  public void UpdateStatus(T entity, Status status)
  {
    if (typeof(BaseEntity).IsAssignableFrom(typeof(T)))
    {
      if (entity is BaseEntity baseEntity)
      {
        baseEntity.Status = status;
        _db.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
      }
    }
  }
}