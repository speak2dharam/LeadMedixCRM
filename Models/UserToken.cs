namespace LeadMedixCRM.Models
{
    public class UserToken
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Token { get; set; }

        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

        public DateTime? RevokedAt { get; set; }

        public bool IsRevoked { get; set; } = false;
    }
}
