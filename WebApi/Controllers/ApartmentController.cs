using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Models;
using WebApi.Services.ApartmentService;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ApartmentDto>>> GetAllApartments([FromQuery]long? userId)
        {
            var apartments = await _apartmentService.GetAllApartmentsAsync(userId);
            return Ok(apartments);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ApartmentDto>> GetApartmentById(long id)
        {
            var apartment = await _apartmentService.GetApartmentByIdAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }
            return Ok(apartment);
        }
        
        [HttpPost]
        public async Task<ActionResult<ApartmentDto>> Create(CreateApartmentDto createApartmentDto)
        {
            var createdApartment = await _apartmentService.CreateApartmentAsync(createApartmentDto);
            if (createdApartment == null)
            {
                return BadRequest();
            }
            return Ok(createApartmentDto);
        }
        
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateApartment([Required]long id, [Required][FromBody]UpdateApartmentDto updateApartmentDto)
        {
            await _apartmentService.UpdateApartmentAsync(id, updateApartmentDto);

            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> DeleteApartment([Required]long id)
        {
            await _apartmentService.DeleteApartmentAsync(id);
            return NoContent();
        }
        
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ApartmentDto>>> SearchAsync([FromQuery] SearchDto searchDto)
        {
            var apartments = await _apartmentService.SearchByParamsAsync(searchDto);
            return Ok(apartments);
        }

        [HttpPost("reports/create")]
        public async Task<ActionResult> ReportApartment(ApartmentReportDto.CreateReportDto reportDto)
        {
            return Ok(await _apartmentService.ReportApartmentAsync(reportDto));
        }
        
        [HttpGet("reports/all")]
        public async Task<ActionResult<IEnumerable<ApartmentReportDto.ReportDto>>> GetAllReports(bool includeResolved = false)
        {
            return Ok(await _apartmentService.GetAllReports(includeResolved));
        }

        [HttpPost("reports/resolve")]
        public async Task<ActionResult> ResolveReport([FromRoute] Guid reportId, bool deleteApartment)
        {
            var response = await _apartmentService.ResolveReport(reportId, deleteApartment);
            if (response)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
