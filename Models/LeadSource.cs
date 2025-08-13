using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class LeadSource
    {
        [Key]
        public int LeadSourceId { get; set; }

        [Required, MaxLength(50)]
        public string SourceName { get; set; }
        public string Description { get; set; }
    }
}
