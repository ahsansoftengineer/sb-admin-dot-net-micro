using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs.Donation;
public class TargetAssignmentDto : BaseDtoFull
{
  public DateTime TargetFrom { get; set; }
  public DateTime TargetFor { get; set; }
  public int IncreasePercentage { get; set; }

  public int SystemzId { get; set; }
  public BaseDtoSelect? Systemz { get; set; }

  public int MajlisId { get; set; }
  public BaseDtoSelect? Majlis { get; set; }

  public int SUId { get; set; }
  public BaseDtoSelect? SU { get; set; }
}
public class TargetAssignmentDtoCreate : BaseDtoCreate
{
  public DateTime TargetFrom { get; set; }
  public DateTime TargetFor { get; set; }
  public int IncreasePercentage { get; set; }
  public int SystemzId { get; set; }
  public int MajlisId { get; set; }
  public int SUId { get; set; }
}
public class TargetAssignmenteDtoSearch : BaseDtoSearchFull
{
  public DateTime? TargetFrom { get; set; }
  public DateTime? TargetFor { get; set; }
  public int? IncreasePercentage { get; set; }
  public int? SystemzId { get; set; }
  public int? MajlisId { get; set; }
  public int? SUId { get; set; }
}