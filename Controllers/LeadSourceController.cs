using LeadMedixCRM.DTOs;
using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LeadMedixCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LeadSourceController : ControllerBase
    {
        private readonly ILeadSourceService _leadSourceService;
        public LeadSourceController(ILeadSourceService leadSourceService) 
        { 
            _leadSourceService = leadSourceService;
        }
        [HttpGet]
        //public IActionResult GetAll() => Ok(_leadSourceService.GetAllAsync());
        public async Task<IActionResult> GetAll()
        {
            var leadsource = await _leadSourceService.GetAllAsync();
            return Ok(leadsource);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var source = _leadSourceService.GetById(id);
            if (source == null) return NotFound();
            return Ok(source);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeadSourceDto dto)
        {
            //var created = _leadSourceService.Create(dto);
            //return CreatedAtAction(nameof(GetById), new { id = created. }, created);
            var result = await _leadSourceService.Create(dto);
            return Ok(new { message = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LeadSourceDto dto)
        {
            //var updated = _leadSourceService.Update(id, dto);
            //if (updated == null) return NotFound();
            //return Ok(updated);

            var result = await _leadSourceService.Update(id, dto);
            if (result == null) return NotFound();
            return Ok(new { message = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var result = _leadSourceService.Delete(id);
            //if (!result) return NotFound();
            //return NoContent();
            var result = await _leadSourceService.Delete(id);
            if (!result) return NotFound();
            return Ok(new { message = result });
        }
    }
}
