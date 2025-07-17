using LeadMedixCRM.DTOs;
using LeadMedixCRM.Helpers;
using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadMedixCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService) 
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authUser = AuthClaimsHelper.GetAuthUser(User);

            var roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null) return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleDto dto)
        {
            var result = await _roleService.AddAsync(dto);
            return Ok(new { message = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoleDto dto)
        {
            var result = await _roleService.UpdateAsync(id, dto);
            return Ok(new { message = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roleService.DeleteAsync(id);
            return Ok(new { message = result });
        }
    }
}
