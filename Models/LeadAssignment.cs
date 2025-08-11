using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class LeadAssignment
    {
        [Key]
        public int AssignmentId { get; set; }

        public int LeadId { get; set; }

        public int CoordinatorId { get; set; }

        public int AssignedByUserId { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
