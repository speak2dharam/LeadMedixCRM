using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class Lead
    {
        [Key]
        public int LeadId { get; set; }

        [Required, MaxLength(100)]
        public string PatientName { get; set; }

        public int Age { get; set; }
        [MaxLength(10)]
        public string Gender { get; set; }
        [MaxLength(50)]
        public int CountryID { get; set; }

        [MaxLength(20)]
        public string ContactNumber { get; set; }
        [MaxLength(20)]
        public string WhatsAppNo { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
        public string MedicalIssue { get; set; }
        public int TreatmentCategoryId { get; set; }
        public int LeadSourceId { get; set; }
        public int LeadQualityId { get; set; }

        public int StatusId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
