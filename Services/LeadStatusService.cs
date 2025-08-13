using LeadMedixCRM.Data;
using LeadMedixCRM.DTOs;
using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadMedixCRM.Services
{
    public class LeadStatusService:ILeadStatusService
    {
        private ApplicationDbContext _context;
        public LeadStatusService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LeadStatus>> GetAllAsync()
        {
            return await _context.LeadStatus.ToListAsync();
        }
        public async Task<string> Create(LeadStatusDto dto)
        {
            if (_context.LeadStatus.Any(r => r.StatusName == dto.StatusName))
                throw new Exception("Status already exists.");

            var leadStatus = new LeadStatus { 
                StatusName = dto.StatusName,
                Description= dto.Description,
            };
            _context.LeadStatus.Add(leadStatus);
            await _context.SaveChangesAsync();

            return "Status added successfully.";
        }

        public async Task<bool> Delete(int StatusId)
        {
            var existing = await _context.LeadStatus.FindAsync(StatusId);
            if (existing == null) throw new Exception("Status not found.");

            _context.LeadStatus.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<LeadStatusDto> GetById(int StatusId)
        {
            var entity = await _context.LeadStatus.FindAsync(StatusId);
            if (entity == null) return null;

            return new LeadStatusDto
            {
                StatusId = entity.StatusId,
                StatusName = entity.StatusName,
                Description= entity.Description
            };
        }
        public async Task<LeadStatusDto> Update(int StatusId, LeadStatusDto dto)
        {
            var existing = await _context.LeadStatus.FindAsync(StatusId);
            if (existing == null) throw new Exception("Status not found.");
            if (existing.StatusName==dto.StatusName)
            {
                throw new Exception("Status already found.");
            }
            existing.StatusName = dto.StatusName;
            existing.Description = dto.Description;
            await _context.SaveChangesAsync();
            
            // Map entity to DTO before returning
            return new LeadStatusDto
            {
                StatusId = existing.StatusId,
                StatusName = existing.StatusName
            };
        }
    }
}
