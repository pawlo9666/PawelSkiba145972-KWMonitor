using KoronaWirusMonitor3.Models;
using KoronaWirusMonitor3.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWMonitor.Services
{
    public class CitiesService : ICitiesService
    {

        private readonly KWMContext _context;

        public CitiesService(KWMContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAll()
        {
            var CityList = await _context.Cities.AsNoTracking().AsQueryable().Include(s => s.District).ThenInclude(s=> s.Region).ThenInclude(s => s.Country).ToListAsync();
            return CityList;
        }

        public async Task<City> Add(City City)
        {
            var result = _context.Cities.Add(City);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<City> GetById(int id)
        {
            return await _context.Cities.Where(p => p.Id == id)
                .Include(s => s.District)
                .ThenInclude(s => s.Region)
                .ThenInclude(s => s.Country)
                .FirstOrDefaultAsync();
        }

        public async Task Delete(City city)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

    }
}
