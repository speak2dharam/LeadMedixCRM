using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Data;
using LeadMedixCRM.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using LeadMedixCRM.Models;


namespace LeadMedixCRM.Services
{
    public class AuthService:IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtHelper _jwtHelper;
        public AuthService(ApplicationDbContext context, IJwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }
        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("User already exists");

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _jwtHelper.GenerateToken(user);
        }
        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            return _jwtHelper.GenerateToken(user);
        }
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashed = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            Console.WriteLine("Register hash: " + hashed);
            return Convert.ToBase64String(hashed);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            return HashPassword(password) == storedHash;
        }
    }
    
}
