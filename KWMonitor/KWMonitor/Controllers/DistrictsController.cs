using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KoronaWirusMonitor3.Models;
using KWMonitor.Models;
using KWMonitor.Services;
using KWMonitor.Validators;
using Microsoft.AspNetCore.Mvc;
using smagAPP.Services;

namespace KWMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictsService _districtsService;
        private readonly IMapper _mapper;
        public DistrictsController(IDistrictsService districtsService, IMapper mapper)
        {
            _districtsService = districtsService;
            _mapper = mapper;
        }

        // GET: api/Districts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<District>>> GetDistricts()
        {
            var districts = await _districtsService.GetAll();
            return Ok(_mapper.Map<IEnumerable<DistrictDTO>>(districts));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DistrictDTO>> GetDistrict(int id)
        {
            var district = await _districtsService.GetById(id);
            if (district == null) return NotFound();
            return _mapper.Map<DistrictDTO>(district);
        }


        // POST: api/Districts
        [HttpPost]
        public async Task<ActionResult<CreateDistrict>> PostRegion(CreateDistrict DistrictDto)
        {
            var district = _mapper.Map<District>(DistrictDto);
            var result = await _districtsService.Add(district);
            return CreatedAtAction("GetDistrict", new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrict(int id)
        {
            var country = await _districtsService.GetById(id);
            if (country == null) return NotFound();
            await _districtsService.Delete(country);
            return Ok();
        }

    }
}
