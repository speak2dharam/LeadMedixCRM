using LeadMedixCRM.DTOs;
using LeadMedixCRM.Models;

namespace LeadMedixCRM.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(int id);
        Task<string> AddAsync(RoleDto dto);
        Task<string> UpdateAsync(int id, RoleDto dto);
        Task<string> DeleteAsync(int id);
    }
}
