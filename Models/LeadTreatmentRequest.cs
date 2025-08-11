using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class LeadTreatmentRequest
    {
        [Key]
        public int RequestId { get; set; }

        public int LeadId { get; set; }
        public string LeadName { get; set; }

        public int TreatmentCategoryId { get; set; }
        public string TreatmentCategoryName { get; set; }

        public int OurCoordinatorId { get; set; }
        public string OurCoordinatorName { get; set; }

        public int HospitalId { get; set; }
        public string HospitalName { get; set; }

        public int HospitalCoordinatorId { get; set; }
        public string HospitalCoordinatorName { get; set; }

        public string Status { get; set; } // e.g., "Sent to Hospital", "Plan Received", "Sent to Patient", "Documents Requested"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
