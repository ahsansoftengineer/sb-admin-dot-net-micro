using AutoMapper;
using GLOB.Domain.DTOs;
using GLOB.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using SBA.Hierarchy.App;
using SBA.Hierarchy.Controllers.Base;

namespace SBA.Hierarchy.Controllers;
[Route("api/Hierarchy/[controller]")]
[ApiController]
public class SystemzController : BasezController<SystemzController, Systemz, SystemzDto>
{
  public SystemzController(
    ILogger<SystemzController> logger,
    IMapper mapper,
    IUOW uow) : base(logger, mapper, uow)
  {
    Repo = uow.Systemzs;

  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] SystemzDtoCreate data)
  {
    if (!ModelState.IsValid) return CreateInvalid();
    try
    {
      var result = Mapper.Map<Systemz>(data);
      await Repo.Insert(result);
      await UnitOfWork.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(int id, [FromBody] SystemzDtoCreate data)
  {
    if (!ModelState.IsValid || id < 1) return UpdateInvalid();
    try
    {
      var item = await Repo.Get(q => q.Id == id);

      if (item == null) return UpdateNull();
      var result = Mapper.Map(data, item);
      Repo.Update(item);
      await UnitOfWork.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Update));
    }
  }
}