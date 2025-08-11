using LeadMedixCRM.DTOs;
using LeadMedixCRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeadMedixCRM.Interfaces
{
    public interface IAuthService
    {
        Task<string> AddUserAsync(AddUserDto dto);
        Task<LoginResponseDto> LoginAsync(LoginDto dto);
        bool Logout(string token);
        //Task<IEnumerable<Role>> GetAllUsers();
    }
}
