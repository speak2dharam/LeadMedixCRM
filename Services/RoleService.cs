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

        public async Task<Role?> GetByIdAsync(int RoleID)
        {
            return await _context.Roles.FindAsync(RoleID);
        }

        public async Task<string> AddAsync(RoleDto dto)
        {
            if (_context.Roles.Any(r => r.RoleName == dto.RoleName))
                throw new Exception("Role already exists.");

            var role = new Role { RoleName = dto.RoleName,Description=dto.Description };
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return "Role added successfully.";
        }

        public async Task<string> UpdateAsync(int RoleID, RoleDto dto)
        {
            var role = await _context.Roles.FindAsync(RoleID);
            if (role == null) throw new Exception("Role not found.");

            role.RoleName = dto.RoleName;
            role.Description = dto.Description;
            await _context.SaveChangesAsync();

            return "Role updated.";
        }

        public async Task<string> DeleteAsync(int RoleID)
        {
            var role = await _context.Roles.FindAsync(RoleID);
            if (role == null) throw new Exception("Role not found.");

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return "Role deleted.";
        }
    }
}
