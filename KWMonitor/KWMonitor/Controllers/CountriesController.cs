using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KoronaWirusMonitor3.Models;
using KWMonitor.Services;
using KWMonitor.Validators;
using Microsoft.AspNetCore.Mvc;

namespace KWMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;
        private readonly IMapper _mapper;
        public CountriesController(ICountriesService countriesService , IMapper mapper)
        {
            _countriesService = countriesService;
            _mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var Countries = await _countriesService.GetAll();
            return Ok(_mapper.Map<IEnumerable<CountryDTO>>(Countries));
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _countriesService.GetById(id);
            if (country == null) return NotFound();
            return Ok(_mapper.Map<CountryDTO>(country));
        }

        // PUT: api/Countries/5
        [HttpPut]
        public async Task<IActionResult> PutCountry(Country country)
        {
            var result = await _countriesService.Update(country);
            if (result) return Ok();
            return NoContent();
        }

        // POST: api/Countries
        [HttpPost]
        public async Task<ActionResult<CountryDTO>> PostCountry(CountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);
            var result = await _countriesService.Add(country);
            return CreatedAtAction("GetCountry", new {id = result.Id}, result);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesService.GetById(id);
            if (country == null) return NotFound();
            await _countriesService.Delete(country);
            return Ok();
        }
    }
}
