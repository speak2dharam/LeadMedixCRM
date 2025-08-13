namespace LeadMedixCRM.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
        public string Mobile { get; set; }

        public string PasswordHash { get; set; }

        public int RoleId { get; set; }  // No foreign key constraint

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }
    }
}
