using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KoronaWirusMonitor3.Models;
using KWMonitor.Models;
using KWMonitor.Services;
using KWMonitor.Validators;
using Microsoft.AspNetCore.Mvc;

namespace KWMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionsService _regionsService;
        private readonly IMapper _mapper;
        public RegionsController(IRegionsService regionsService, IMapper mapper)
        {
            _regionsService = regionsService;
            _mapper = mapper;
        }

        // GET: api/Regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            var regions = await _regionsService.GetAll();
            return Ok(_mapper.Map<IEnumerable<RegionDTO>>(regions));
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegionDTO>> GetRegion(int id)
        {
            var region = await _regionsService.GetById(id);
            if (region == null) return NotFound();
            return _mapper.Map<RegionDTO>(region);
        }


        // POST: api/Regions
        [HttpPost]
        public async Task<ActionResult<CreateRegion>> PostRegion(CreateRegion RegionDto)
        {
            var region = _mapper.Map<Region>(RegionDto);
            var result = await _regionsService.Add(region);
            return CreatedAtAction("GetRegion", new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            var country = await _regionsService.GetById(id);
            if (country == null) return NotFound();
            await _regionsService.Delete(country);
            return Ok();
        }


    }
}
