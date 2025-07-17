namespace LeadMedixCRM.Models
{
    public class LoginHistory
    {
        public int Id { get; set; }

        public int UserId { get; set; } // No FK

        public string IPAddress { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime? LogoutTime { get; set; }
    }
}
