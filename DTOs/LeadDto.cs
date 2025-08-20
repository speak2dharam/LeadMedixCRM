using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.DTOs
{
    public class LeadDto
    {
        public int LeadId { get; set; }

        public string PatientName { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }
        public int CountryID { get; set; }

        public string ContactNumber { get; set; }
        public string WhatsAppNo { get; set; }
        public string Email { get; set; }
        public string MedicalIssue { get; set; }
        public int TreatmentCategoryId { get; set; }
        public int LeadSourceId { get; set; }
        public int LeadQualityId { get; set; }

        public int StatusId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
    public class LeadResponseDto
    {
        public int LeadId { get; set; }

        public string PatientName { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }
        public CountryDto Country { get; set; }

        public string ContactNumber { get; set; }
        public string WhatsAppNo { get; set; }
        public string Email { get; set; }
        public string MedicalIssue { get; set; }
        public TreatmentCategoryDto TreatmentCategoryId { get; set; }
        public LeadSourceDto LeadSourceId { get; set; }
        public LeadQualityDto LeadQualityId { get; set; }

        public LeadStatusDto StatusId { get; set; }

        public int CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
    }
}
