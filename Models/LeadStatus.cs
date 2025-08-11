using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class LeadStatus
    {
        [Key]
        public int StatusId { get; set; }

        [Required, MaxLength(50)]
        public string StatusName { get; set; }
    }
}
