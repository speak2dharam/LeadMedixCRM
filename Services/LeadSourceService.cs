using LeadMedixCRM.Data;
using LeadMedixCRM.DTOs;
using LeadMedixCRM.Exceptions;
using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LeadMedixCRM.Services
{
    public class LeadSourceService:ILeadSourceService
    {
        private ApplicationDbContext _context;
        public LeadSourceService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LeadSource>> GetAllAsync()
        {
            return await _context.LeadSource.ToListAsync();
        }
        public async Task<string> Create(LeadSourceDto dto)
        {
            if (_context.LeadSource.Any(r => r.SourceName == dto.SourceName))
                throw new Exception("Source already exists.");
                //throw new ConflictException("Source already exists.");

            var LeadSource = new LeadSource { SourceName = dto.SourceName,Description=dto.Description };
            _context.LeadSource.Add(LeadSource);
            await _context.SaveChangesAsync();

            return "Source added successfully.";
        }

        public async Task<bool> Delete(int LeadSourceId)
        {
            //throw new NotImplementedException();
            var existing = await _context.LeadSource.FindAsync(LeadSourceId);
            if (existing == null) throw new Exception("Source not found.");

            _context.LeadSource.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<LeadSourceDto> GetById(int LeadSourceId)
        {
            //return await _context.LeadSource.FindAsync(id);
            var entity = await _context.LeadSource.FindAsync(LeadSourceId);
            if (entity == null) return null;

            return new LeadSourceDto
            {
                LeadSourceId = entity.LeadSourceId,
                SourceName = entity.SourceName,
                Description = entity.Description
            };
        }

        public async Task<LeadSourceDto> Update(int LeadSourceId, LeadSourceDto dto)
        {
            //var existing = await _context.LeadSource.FindAsync(id);
            //if (existing == null) throw new Exception("Source not found.");

            //existing.SourceName = dto.SourceName;
            //await _context.SaveChangesAsync();

            //return existing;

            var existing = await _context.LeadSource.FindAsync(LeadSourceId);
            if (existing == null) throw new Exception("Source not found.");
            if (existing.SourceName == dto.SourceName)
            {
                throw new Exception("Source already found.");
            }

            existing.SourceName = dto.SourceName;
            existing.Description = dto.Description;
            await _context.SaveChangesAsync();

            // Map entity to DTO before returning
            return new LeadSourceDto
            {
                LeadSourceId = existing.LeadSourceId,
                SourceName = existing.SourceName
            };
        }

        
    }
}
