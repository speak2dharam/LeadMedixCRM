using Azure.Core;
using LeadMedixCRM.Data;
using LeadMedixCRM.DTOs;
using LeadMedixCRM.Helpers;
using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;



namespace LeadMedixCRM.Services
{
    public class AuthService:IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtHelper _jwtHelper;
        public AuthService(ApplicationDbContext context, JwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }
        public async Task<string> AddUserAsync(AddUserDto dto)
        {
            if (_context.Users.Any(u => u.Email == dto.Email))
                throw new Exception("User already exists.");

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Mobile=dto.Mobile,
                RoleId = dto.RoleId,
                //PasswordHash = PasswordHasher.HashPassword(dto.Password),
                PasswordHash = dto.Password,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "User added successfully.";
        }
        public bool Logout(string token)
        {
            var tokenInDb = _context.UserTokens.FirstOrDefault(u => u.Token == token);
            if (tokenInDb != null)
            {
                tokenInDb.IsRevoked = true;
                tokenInDb.RevokedAt = DateTime.UtcNow;
                _context.SaveChanges();
            }

            return true;
        }
        public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email && u.PasswordHash==dto.Password);

            //if (user == null || !PasswordHasher.Verify(dto.Password, user.PasswordHash))
            //    throw new Exception("Invalid email or password.");

            if (user!=null)
            {
                if (!user.IsActive)
                    throw new Exception("User is disabled.");
                else
                {
                    var getToken = _jwtHelper.GenerateToken(user);

                    _context.UserTokens.Add(new UserToken
                    {
                        UserId = user.Id,
                        Token = getToken
                    });

                    await _context.SaveChangesAsync();

                    return new LoginResponseDto
                    {
                        Token = getToken,
                        UserName=user.FullName,
                        UserId = user.Id,
                        Email = user.Email,
                        UserRole = user.RoleId,
                        profilePic = ""
                    };

                    //return getToken;
                }
            }
            else
            {
                throw new Exception("Invalid email or password.");
            }
            

            // Save login history
            //_context.LoginHistories.Add(new LoginHistory
            //{
            //    UserId = user.Id,
            //    IPAddress = ip,
            //    LoginTime = DateTime.UtcNow
            //});

            // Save device info
            //_context.UserDevices.Add(new UserDevice
            //{
            //    UserId = user.Id,
            //    DeviceInfo = device,
            //    IPAddress = ip,
            //    LastUsed = DateTime.UtcNow
            //});
            
        }
        

    }

}
