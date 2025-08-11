using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class TreatmentPlan
    {
        [Key]
        public int TreatmentPlanId { get; set; }

        public int LeadId { get; set; }

        public int HospitalId { get; set; }

        public int DoctorId { get; set; }

        public string DoctorProfileFilePath { get; set; }
        public string HospitalProspectusFilePath { get; set; }

        public string PlanDetails { get; set; }
        public decimal EstimatedCost { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
