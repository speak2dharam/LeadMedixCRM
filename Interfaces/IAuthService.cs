using LeadMedixCRM.DTOs;

namespace LeadMedixCRM.Interfaces
{
    public interface IAuthService
    {
        Task<string> AddUserAsync(AddUserDto dto);
        Task<string> LoginAsync(LoginDto dto, string ip, string device);
    }
}
