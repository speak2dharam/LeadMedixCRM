using LeadMedixCRM.DTOs;
using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeadMedixCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeadStatusController : ControllerBase
    {
        private readonly ILeadStatusService _leadStatusService;
        public LeadStatusController(ILeadStatusService leadStatusService)
        {
            _leadStatusService = leadStatusService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leadStatus = await _leadStatusService.GetAllAsync();
            return Ok(leadStatus);
        }

        [HttpGet("{StatusId}")]
        public async Task<IActionResult> GetById(int StatusId)
        {
            var source = await _leadStatusService.GetById(StatusId);
            if (source == null) return NotFound();
            return Ok(source);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeadStatusDto dto)
        {
            var result = await _leadStatusService.Create(dto);
            return Ok(new { message = result });
        }

        [HttpPut("{StatusId}")]
        public async Task<IActionResult> Update(int StatusId, [FromBody] LeadStatusDto dto)
        {
            var result = await _leadStatusService.Update(StatusId, dto);
            if (result == null) return NotFound();
            return Ok(new { message = result });
        }

        [HttpDelete("{StatusId}")]
        public async Task<IActionResult> Delete(int StatusId)
        {
            var result = await _leadStatusService.Delete(StatusId);
            if (!result) return NotFound();
            return Ok(new { message = result });
        }
    }
}
