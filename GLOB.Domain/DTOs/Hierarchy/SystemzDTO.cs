using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs;
public class SystemzDto : DtoRead
{
  public int OrgId { get; set; }
  public DtoSelect? Org { get; set; }
}
public class SystemzDtoCreate : DtoCreate
{
  public int OrgId { get; set; }
}
public class SystemzDtoSearch : BaseDtoSearchFull
{
  public int? OrgId { get; set; }
}