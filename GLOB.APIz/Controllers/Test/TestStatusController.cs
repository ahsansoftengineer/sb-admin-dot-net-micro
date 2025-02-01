using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Apps.Common;
using GLOB.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GLOB.API.Controllers.Test;
[Route("api/[controller]")]
[ApiController]
public class TestStatusController : CommonStatusController<TestStatusController, TestStatus>
{
  public TestStatusController(
    ILogger<TestStatusController> logger,
    IMapper mapper,
    IUnitOfWorkz unitOfWork) : base(logger, mapper, unitOfWork)
  {
    Repo = unitOfWork.TestStatus;
  }
}