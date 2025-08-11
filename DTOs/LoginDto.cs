namespace LeadMedixCRM.DTOs
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public int UserRole { get; set; }
        public string profilePic { get; set; }
    }
}
