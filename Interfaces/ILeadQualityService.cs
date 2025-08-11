using LeadMedixCRM.DTOs;

namespace LeadMedixCRM.Interfaces
{
    public interface ILeadQualityService
    {
        IEnumerable<LeadQualityDto> GetAll();
        LeadQualityDto GetById(int id);
        LeadQualityDto Create(LeadQualityDto dto);
        LeadQualityDto Update(int id, LeadQualityDto dto);
        bool Delete(int id);
    }
}
