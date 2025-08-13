using LeadMedixCRM.Data;
using LeadMedixCRM.DTOs;
using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadMedixCRM.Services
{
    public class LeadQualityService:ILeadQualityService
    {
        private ApplicationDbContext _context;
        public LeadQualityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Create(LeadQualityDto dto)
        {
            if (_context.LeadQuality.Any(r => r.QualityName == dto.QualityName))
                throw new Exception("Quality Name already exists.");

            var LeadQuality = new LeadQuality { QualityName = dto.QualityName,Description=dto.Description };
            _context.LeadQuality.Add(LeadQuality);
            await _context.SaveChangesAsync();

            return "Quality name added successfully.";
        }

        public Task<bool> Delete(int LeadQualityId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LeadQuality>> GetAllAsync()
        {
            return await _context.LeadQuality.ToListAsync();
        }

        public async Task<LeadQualityDto> GetById(int LeadQualityId)
        {
            var entity = await _context.LeadQuality.FindAsync(LeadQualityId);
            if (entity == null) return null;

            return new LeadQualityDto
            {
                LeadQualityId = entity.LeadQualityId,
                QualityName = entity.QualityName,
                Description=entity.Description
            };
        }

        public async Task<LeadQualityDto> Update(int LeadQualityId, LeadQualityDto dto)
        {
            var existing = await _context.LeadQuality.FindAsync(LeadQualityId);
            if (existing == null) throw new Exception("Quality not found.");
            if (existing.QualityName == dto.QualityName)
            {
                throw new Exception("Quality Name already found.");
            }
            existing.QualityName = dto.QualityName;
            existing.Description = dto.Description;
            await _context.SaveChangesAsync();

            // Map entity to DTO before returning
            return new LeadQualityDto
            {
                LeadQualityId = existing.LeadQualityId,
                QualityName = existing.QualityName
            };
        }
    }
}
