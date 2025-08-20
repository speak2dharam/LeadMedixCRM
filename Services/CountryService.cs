using LeadMedixCRM.Data;
using LeadMedixCRM.DTOs;
using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadMedixCRM.Services
{
    public class CountryService:ICountryService
    {
        private ApplicationDbContext _context;
        public CountryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Country.ToListAsync();
        }

        public async Task<CountryDto> GetById(int CountryId)
        {
            var entity = await _context.Country.FindAsync(CountryId);
            if (entity == null) return null;

            return new CountryDto
            {
                CountryId = entity.CountryId,
                CountryName = entity.CountryName,
                Alpha2Code = entity.Alpha2Code,
                Alpha3Code = entity.Alpha3Code,
                NumericCode = entity.NumericCode,
                PhoneCode = entity.PhoneCode,
            };
        }
    }
}
