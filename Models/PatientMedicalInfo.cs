using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class PatientMedicalInfo
    {
        [Key]
        public int MedicalInfoId { get; set; }

        public int LeadId { get; set; }
        public string ConditionDescription { get; set; }
        public string ReportsPath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
