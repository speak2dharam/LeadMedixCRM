using LeadMedixCRM.DTOs;
using LeadMedixCRM.Models;

namespace LeadMedixCRM.Interfaces
{
    public interface ILeadSourceService
    {
        //IEnumerable<LeadSourceDto> GetAll();
        Task<IEnumerable<LeadSource>> GetAllAsync();
        Task<LeadSourceDto> GetById(int LeadSourceId);
        Task<string> Create(LeadSourceDto dto);
        Task<LeadSourceDto> Update(int LeadSourceId, LeadSourceDto dto);
        Task<bool> Delete(int LeadSourceId);
    }
}
