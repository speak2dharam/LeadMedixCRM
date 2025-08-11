using LeadMedixCRM.DTOs;

namespace LeadMedixCRM.Interfaces
{
    public interface ILeadStatusService
    {
        IEnumerable<LeadStatusDto> GetAll();
        LeadStatusDto GetById(int id);
        LeadStatusDto Create(LeadStatusDto dto);
        LeadStatusDto Update(int id, LeadStatusDto dto);
        bool Delete(int id);
    }
}
