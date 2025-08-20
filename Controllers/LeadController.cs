using LeadMedixCRM.DTOs;
using LeadMedixCRM.Helpers;
using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadMedixCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _leadService;
        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authUser = AuthClaimsHelper.GetAuthUser(User);

            //var ausr = new AuthUserDto
            //{
            //    UserId = authUser.UserId,
            //    Email = authUser.Email,
            //    FullName = authUser.FullName,
            //    Role = authUser.Role
            //};
            var leads = await _leadService.GetAllAsync(authUser);
            return Ok(leads);
        }

        [HttpGet("{LeadId}")]
        public async Task<IActionResult> GetById(int LeadId)
        {
            var authUser = AuthClaimsHelper.GetAuthUser(User);

            var source = await _leadService.GetById(LeadId, authUser);
            if (source == null) return NotFound();
            return Ok(source);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeadDto dto)
        {
            var result = await _leadService.Create(dto);
            return Ok(new { message = result });
        }

        [HttpPut("{LeadId}")]
        public async Task<IActionResult> Update(int LeadId, [FromBody] LeadDto dto)
        {
            var result = await _leadService.Update(LeadId, dto);
            if (result == null) return NotFound();
            return Ok(new { message = result });
        }

        //[HttpDelete("{LeadId}")]
        //public async Task<IActionResult> Delete(int LeadId)
        //{
        //    var result = await _leadService.Delete(LeadId);
        //    if (!result) return NotFound();
        //    return Ok(new { message = result });
        //}
    }
}
