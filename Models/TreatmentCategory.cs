using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class TreatmentCategory
    {
        [Key]
        public int TreatmentCategoryId { get; set; }

        [Required, MaxLength(100)]
        public string CategoryName { get; set; } // e.g., "Orthopedic Surgery", "Cancer Treatment"

        public string Description { get; set; }
    }
}
