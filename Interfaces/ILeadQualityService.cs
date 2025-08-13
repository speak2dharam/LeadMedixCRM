using LeadMedixCRM.DTOs;
using LeadMedixCRM.Models;

namespace LeadMedixCRM.Interfaces
{
    public interface ILeadQualityService
    {
        Task<IEnumerable<LeadQuality>> GetAllAsync();
        Task<LeadQualityDto> GetById(int LeadQualityId);
        Task<string> Create(LeadQualityDto dto);
        Task<LeadQualityDto> Update(int LeadQualityId, LeadQualityDto dto);
        Task<bool> Delete(int LeadQualityId);
    }
}
