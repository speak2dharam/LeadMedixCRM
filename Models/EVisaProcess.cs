using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class EVisaProcess
    {
        [Key]
        public int EVisaId { get; set; }

        public int LeadId { get; set; }
        public string LeadName { get; set; }

        public DateTime DocumentsRequestedDate { get; set; }
        public DateTime DocumentsReceivedDate { get; set; }
        public DateTime AppliedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }

        public string Status { get; set; } // e.g., "Pending", "Applied", "Approved", "Rejected"

        public string Notes { get; set; }
    }
}
