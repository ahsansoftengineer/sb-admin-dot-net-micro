// using AutoMapper;
// using GLOB.API.Controllers.Base;
// using GLOB.Domain.Entity;
// using Microsoft.AspNetCore.Mvc;
// using SBA.Hierarchy.Data;

// namespace SBA.Hierarchy.Controllers.Prime;
// [Route("api/Hierarchy/[controller]")]
// [ApiController]
// public class IndustryController : CommonController<IndustryController, Industry>
// {
//   public IndustryController(
//     ILogger<IndustryController> logger,
//     IMapper mapper,
//     IUOW uow) : base(logger, mapper, uow)
//   {
//     Repo = uow.Industrys;

//   }
// }