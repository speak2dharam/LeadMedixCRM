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
    public class TreatmentCategoryController : ControllerBase
    {
        private readonly ITreatmentCategoryService _treatmentcategory;
        public TreatmentCategoryController(ITreatmentCategoryService treatmentcategory)
        {
            _treatmentcategory = treatmentcategory;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var treatmentcategory = await _treatmentcategory.GetAllAsync();
            return Ok(treatmentcategory);
        }

        [HttpGet("{TreatmentCategoryId}")]
        public async Task<IActionResult> GetById(int TreatmentCategoryId)
        {
            var source = await _treatmentcategory.GetById(TreatmentCategoryId);
            if (source == null) return NotFound();
            return Ok(source);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TreatmentCategoryDto dto)
        {
            var result = await _treatmentcategory.Create(dto);
            return Ok(new { message = result });
        }

        [HttpPut("{TreatmentCategoryId}")]
        public async Task<IActionResult> Update(int TreatmentCategoryId, [FromBody] TreatmentCategoryDto dto)
        {
            var result = await _treatmentcategory.Update(TreatmentCategoryId, dto);
            if (result == null) return NotFound();
            return Ok(new { message = result });
        }

        [HttpDelete("{TreatmentCategoryId}")]
        public async Task<IActionResult> Delete(int TreatmentCategoryId)
        {
            var result = await _treatmentcategory.Delete(TreatmentCategoryId);
            if (!result) return NotFound();
            return Ok(new { message = result });
        }
    }
}
