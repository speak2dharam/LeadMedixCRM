namespace LeadMedixCRM.Models
{
    public class UserActivity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string ActivityType { get; set; } // e.g., "Login", "EditPatient"

        public string Description { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
