using System.ComponentModel.DataAnnotations.Schema;

namespace GLOB.Domain.Entity;
public class UserBusiness : UserNormal
{
  // public required string BusinessOwner { get; set; }
  public required string UrlBusinessWebsite { get; set; }
  public required string ContactPerson { get; set; }
  [NotMapped]
  public ICollection<Mapping_UserBusinessIndustry>? UserBusinessIndustry { get; set; } = new List<Mapping_UserBusinessIndustry>();
  public ICollection<OrderBusiness>? OrderBusinesss { get; set; } = new List<OrderBusiness>();

}
