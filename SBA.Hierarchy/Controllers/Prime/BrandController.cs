// using AutoMapper;
// using GLOB.API.Controllers.Base;
// using GLOB.Domain.Entity;
// using Microsoft.AspNetCore.Mvc;
// using SBA.Hierarchy.Data;

// namespace SBA.Hierarchy.Controllers.Prime;
// [Route("api/Hierarchy/[controller]")]
// [ApiController]
// public class BrandController : CommonController<BrandController, Brand>
// {
//   public BrandController(
//     ILogger<BrandController> logger,
//     IMapper mapper,
//     IUOW uow) : base(logger, mapper, uow)
//   {
//     Repo = uow.Brands;

//   }
// }