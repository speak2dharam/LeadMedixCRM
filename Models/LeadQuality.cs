using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class LeadQuality
    {
        [Key]
        public int LeadQualityId { get; set; }

        [Required, MaxLength(20)]
        public string QualityName { get; set; }
    }
}
