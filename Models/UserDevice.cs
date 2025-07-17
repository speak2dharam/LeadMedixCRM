namespace LeadMedixCRM.Models
{
    public class UserDevice
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string DeviceInfo { get; set; }

        public string IPAddress { get; set; }

        public DateTime LastUsed { get; set; } = DateTime.UtcNow;
    }
}
