using GLOB.Domain.Base;
using GLOB.Domain.Enums;

namespace GLOB.Domain.DTOs.Donor;
public class DonorBasicDto : BaseDtoFull
{
  public string? Mobile { get; set; }
  public string? Email { get; set; }
  public string? Address { get; set; }
  public Gender? Gender { get; set; }// = Gender.None;

  public int DonorTypeId { get; set; }
  public BaseDtoSelect? DonorType { get; set; }

  public int OrgId { get; set; }
  public BaseDtoSelect? Org { get; set; }

  public int CityId { get; set; }
  public BaseDtoSelect? City { get; set; }

}
public class DonorBasicDtoCreate : BaseDtoCreate
{
  public string Mobile { get; set; }
  public string? Email { get; set; }
  public string? Address { get; set; }
  public Gender? Gender { get; set; }// = Gender.None;

  public int DonorTypeId { get; set; }
  public int OrgId { get; set; }
  public int CityId { get; set; }
}
public class DonorBasicDtoSearch : BaseDtoSearchFull
{
  public string? Mobile { get; set; }
  public string? Email { get; set; }
  public string? Address { get; set; }
  public Gender? Gender { get; set; }// = Gender.None;
  public int? DonorTypeId { get; set; }
  public int? OrgId { get; set; }
  public int? CityId { get; set; }
}