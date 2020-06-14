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
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesService _citiesService;
        private readonly IMapper _mapper;
        public CitiesController(ICitiesService citiesService, IMapper mapper)
        {
            _citiesService = citiesService;
            _mapper = mapper;
        }

        // GET: api/Districts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetCities()
        {
            var cities = await _citiesService.GetAll();
            return Ok(_mapper.Map<IEnumerable<CityDTO>>(cities));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDTO>> GetCity(int id)
        {
            var city = await _citiesService.GetById(id);
            if (city == null) return NotFound();
            return _mapper.Map<CityDTO>(city);
        }


        // POST: api/Districts
        [HttpPost]
        public async Task<ActionResult<CreateDistrict>> PostCity(CreateCity CityDto)
        {
            var city = _mapper.Map<City>(CityDto);
            var result = await _citiesService.Add(city);
            return CreatedAtAction("GetCity", new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _citiesService.GetById(id);
            if (city == null) return NotFound();
            await _citiesService.Delete(city);
            return Ok();
        }

    }
}
