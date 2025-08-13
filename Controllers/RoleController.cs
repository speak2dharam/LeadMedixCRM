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

        [HttpGet("{RoleID}")]
        public async Task<IActionResult> Get(int RoleID)
        {
            var role = await _roleService.GetByIdAsync(RoleID);
            if (role == null) return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleDto dto)
        {
            var result = await _roleService.AddAsync(dto);
            return Ok(new { message = result });
        }

        [HttpPut("{RoleID}")]
        public async Task<IActionResult> Update(int RoleID, RoleDto dto)
        {
            var result = await _roleService.UpdateAsync(RoleID, dto);
            return Ok(new { message = result });
        }

        [HttpDelete("{RoleID}")]
        public async Task<IActionResult> Delete(int RoleID)
        {
            var result = await _roleService.DeleteAsync(RoleID);
            return Ok(new { message = result });
        }
    }
}
