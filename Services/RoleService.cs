using LeadMedixCRM.Data;
using LeadMedixCRM.DTOs;
using LeadMedixCRM.Helpers;
using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadMedixCRM.Services
{
    public class RoleService: IRoleService
    {
        private ApplicationDbContext _context;
        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<string> AddAsync(RoleDto dto)
        {
            if (_context.Roles.Any(r => r.Name == dto.Name))
                throw new Exception("Role already exists.");

            var role = new Role { Name = dto.Name };
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return "Role added successfully.";
        }

        public async Task<string> UpdateAsync(int id, RoleDto dto)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) throw new Exception("Role not found.");

            role.Name = dto.Name;
            await _context.SaveChangesAsync();

            return "Role updated.";
        }

        public async Task<string> DeleteAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) throw new Exception("Role not found.");

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return "Role deleted.";
        }
    }
}
