using LeadMedixCRM.DTOs;
using LeadMedixCRM.Models;

namespace LeadMedixCRM.Interfaces
{
    public interface ILeadService
    {
        Task<IEnumerable<LeadResponseDto>> GetAllAsync(AuthUserDto adto);
        Task<LeadResponseDto> GetById(int LeadId, AuthUserDto adto);
        Task<string> Create(LeadDto dto);
        Task<LeadDto> Update(int LeadId, LeadDto dto);
        Task<bool> Delete(int LeadId);
    }
}
