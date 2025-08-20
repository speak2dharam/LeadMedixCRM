using LeadMedixCRM.Data;
using LeadMedixCRM.DTOs;
using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadMedixCRM.Services
{
    public class TreatmentCategoryService:ITreatmentCategoryService
    {
        private ApplicationDbContext _context;
        public TreatmentCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Create(TreatmentCategoryDto dto)
        {
            if (_context.TreatmentCategory.Any(r => r.CategoryName == dto.CategoryName))
                throw new Exception("Treatment name already exists.");

            var TreatmentCategory = new TreatmentCategory
            {
                CategoryName = dto.CategoryName,
                Description = dto.Description,
            };
            _context.TreatmentCategory.Add(TreatmentCategory);
            await _context.SaveChangesAsync();

            return "Treatment added successfully.";
        }

        public async Task<bool> Delete(int TreatmentCategoryId)
        {
            var existing = await _context.TreatmentCategory.FindAsync(TreatmentCategoryId);
            if (existing == null) throw new Exception("Treatment not found.");

            _context.TreatmentCategory.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TreatmentCategory>> GetAllAsync()
        {
            return await _context.TreatmentCategory.ToListAsync();
        }

        public async Task<TreatmentCategoryDto> GetById(int TreatmentCategoryId)
        {
            var entity = await _context.TreatmentCategory.FindAsync(TreatmentCategoryId);
            if (entity == null) return null;

            return new TreatmentCategoryDto
            {
                TreatmentCategoryId = entity.TreatmentCategoryId,
                CategoryName = entity.CategoryName,
                Description = entity.Description
            };
        }

        public async Task<TreatmentCategoryDto> Update(int TreatmentCategoryId, TreatmentCategoryDto dto)
        {
            var existing = await _context.TreatmentCategory.FindAsync(TreatmentCategoryId);
            if (existing == null) throw new Exception("Treatment not found.");
            if (existing.CategoryName == dto.CategoryName)
            {
                throw new Exception("Treatment already found.");
            }
            existing.CategoryName = dto.CategoryName;
            existing.Description = dto.Description;
            await _context.SaveChangesAsync();

            // Map entity to DTO before returning
            return new TreatmentCategoryDto
            {
                TreatmentCategoryId = existing.TreatmentCategoryId,
                CategoryName = existing.CategoryName,
                Description= existing.Description
            };
        }
    }
}
