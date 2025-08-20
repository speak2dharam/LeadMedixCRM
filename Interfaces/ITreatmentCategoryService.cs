using LeadMedixCRM.DTOs;
using LeadMedixCRM.Models;

namespace LeadMedixCRM.Interfaces
{
    public interface ITreatmentCategoryService
    {
        Task<IEnumerable<TreatmentCategory>> GetAllAsync();
        Task<TreatmentCategoryDto> GetById(int TreatmentCategoryId);
        Task<string> Create(TreatmentCategoryDto dto);
        Task<TreatmentCategoryDto> Update(int TreatmentCategoryId, TreatmentCategoryDto dto);
        Task<bool> Delete(int TreatmentCategoryId);
    }
}
