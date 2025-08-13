using LeadMedixCRM.DTOs;
using LeadMedixCRM.Models;

namespace LeadMedixCRM.Interfaces
{
    public interface ILeadStatusService
    {
        Task<IEnumerable<LeadStatus>> GetAllAsync();
        Task<LeadStatusDto> GetById(int StatusId);
        Task<string> Create(LeadStatusDto dto);
        Task<LeadStatusDto> Update(int StatusId, LeadStatusDto dto);
        Task<bool> Delete(int StatusId);
    }
}
