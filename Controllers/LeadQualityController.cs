using LeadMedixCRM.DTOs;
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
    public class LeadQualityController : ControllerBase
    {
        private readonly ILeadQualityService _leadQualityService;
        public LeadQualityController(ILeadQualityService leadQualityService)
        {
            _leadQualityService = leadQualityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leadStatus = await _leadQualityService.GetAllAsync();
            return Ok(leadStatus);
        }

        [HttpGet("{LeadQualityId}")]
        public async Task<IActionResult> GetById(int LeadQualityId)
        {
            var source = await _leadQualityService.GetById(LeadQualityId);
            if (source == null) return NotFound();
            return Ok(source);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeadQualityDto dto)
        {
            var result = await _leadQualityService.Create(dto);
            return Ok(new { message = result });
        }

        [HttpPut("{LeadQualityId}")]
        public async Task<IActionResult> Update(int LeadQualityId, [FromBody] LeadQualityDto dto)
        {
            var result = await _leadQualityService.Update(LeadQualityId, dto);
            if (result == null) return NotFound();
            return Ok(new { message = result });
        }

        //[HttpDelete("{StatusId}")]
        //public async Task<IActionResult> Delete(int StatusId)
        //{
        //    var result = await _leadStatusService.Delete(StatusId);
        //    if (!result) return NotFound();
        //    return Ok(new { message = result });
        //}
    }
}
