namespace LeadMedixCRM.DTOs
{
    public class AddUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
