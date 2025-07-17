namespace LeadMedixCRM.Helpers
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool Verify(string password, string hashed)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashed);
        }
    }
}
