using AutoMapper;
using GLOB.Apps.Common;
using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract partial class BaseController<TController, TEntity, DtoResponse>
  : AlphaController<TController>
    where TEntity : BaseEntity
    where TController : class
    where DtoResponse : class
{
  protected IRepoGenericz<TEntity> Repo = null;
  protected IUnitOfWorkz UnitOfWork { get; }
  public BaseController(ILogger<TController> logger, IMapper mapper, IUnitOfWorkz unitOfWork) : base(logger, mapper)
  {
    UnitOfWork = unitOfWork;
  } 
  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id)
  {
    if (id < 1) return InvalidId();

    var item = await Repo.Get(id);
    if (item == null) return InvalidId();

    try
    {
      await Repo.Delete(id);
      await UnitOfWork.Save();
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Delete));
    }
    return NoContent();
  }
  [HttpPut("status/{id:int}")]
  public async Task<IActionResult> Status(int id, [FromBody] Status status)
  {
    if (!ModelState.IsValid) return BadRequestz();
    if(!Enum.IsDefined(status)) return InvalidStatus();
    try
    {
      var item = await Repo.Get(id);

      if (item == null) return InvalidId();

      Repo.UpdateStatus(item, status);
      await UnitOfWork.Save();
      return Ok(item);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Status));
    }
  }
  
}