// using AutoMapper;
// using GLOB.Domain.Base;
// using GLOB.Domain.DTOs;
// using GLOB.Domain.Hierarchy;
// using Microsoft.AspNetCore.Mvc;
// using SBA.Projectz.Data;
// using SBA.Projectz.Controllers.Base;

// namespace SBA.Hierarchy.Controllers;
// [Route("api/Hierarchy/[controller]")]
// [ApiController]
// public class CityController : BasezController<CityController, City, CityDto>
// {
//   public CityController(
//     ILogger<CityController> logger,
//     IMapper mapper,
//     IUOW uow) : base(logger, mapper, uow)
//   {
//     Repo = uow.Citys;
//   }

//   [HttpGet("GetsPaginate")]
//   public async Task<IActionResult> GetsPaginate([FromQuery] PaginateRequestFilter<City, CityDtoSearch?> req)
//   {
//     try
//     {
//       var list = await Repo.GetsPaginate(req);
//       return Ok(list);
//     }
//     catch (Exception ex)
//     {
//       return CatchException(ex, nameof(Gets));
//     }
//   }

//   [HttpPost]
//   public async Task<IActionResult> Create([FromBody] CityDtoCreate data)
//   {
//     if (!ModelState.IsValid) return BadRequestz();
//     try
//     {
//       bool hasParent = uOW.States.AnyId(data.StateId);
//       if(!hasParent) return InvalidId("Invalid State");

//       var result = Mapper.Map<City>(data);
//       await Repo.Insert(result);
//       await UnitOfWork.Save();
//       return Ok(result);
//     }
//     catch (Exception ex)
//     {
//       return CatchException(ex, nameof(Create));
//     }
//   }

//   [HttpPut("{id:int}")]
//   public async Task<IActionResult> Update(int id, [FromBody] CityDtoCreate data)
//   {
//     if (!ModelState.IsValid || id < 1) return InvalidId();
//     try
//     {
//       var item = await Repo.Get(q => q.Id == id);
//       if (item == null) return InvalidId();
      
//       bool hasParent = uOW.States.AnyId(data.StateId);
//       if(!hasParent) return InvalidId("Invalid State");

//       var result = Mapper.Map(data, item);
//       Repo.Update(item);
//       await UnitOfWork.Save();
//       return Ok(result);
//     }
//     catch (Exception ex)
//     {
//       return CatchException(ex, nameof(Update));
//     }
//   }
// }