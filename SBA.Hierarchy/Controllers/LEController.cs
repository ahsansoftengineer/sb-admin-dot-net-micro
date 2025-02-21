using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using GLOB.Domain.DTOs;
using GLOB.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using SBA.Hierarchy.App;

namespace SBA.Hierarchy.Controllers.Test;
[Route("api/Hierarchy/[controller]")]
[ApiController]
public class LEController : BaseController<LEController, LE, LEDto>
{
  public LEController(
    ILogger<LEController> logger,
    IMapper mapper,
    IUOW uow) : base(logger, mapper, uow)
  {
    Repo = uow.LEs;

  }

  [HttpGet("GetsPaginate")]
  public async Task<IActionResult> GetsPaginate([FromQuery] PaginateRequestFilter<LE, LEDtoSearch> req)
  {
    try
    {
      var list = await Repo.GetsPaginate(req);
      return Ok(list);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Gets));
    }
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] LEDtoCreate data)
  {
    if (!ModelState.IsValid) return CreateInvalid();
    try
    {
      var result = Mapper.Map<LE>(data);
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
  public async Task<IActionResult> Update(int id, [FromBody] LEDtoCreate data)
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