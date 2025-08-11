using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class LeadHistory
    {
        [Key]
        public int HistoryId { get; set; }

        public int LeadId { get; set; }

        public int StatusId { get; set; }

        public int UpdatedByUserId { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
