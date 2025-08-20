using LeadMedixCRM.DTOs;
using LeadMedixCRM.Models;

namespace LeadMedixCRM.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllAsync();
        Task<CountryDto> GetById(int CountryId);
    }
}
