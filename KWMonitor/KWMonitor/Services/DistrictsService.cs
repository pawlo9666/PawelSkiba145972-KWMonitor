using KoronaWirusMonitor3.Models;
using KoronaWirusMonitor3.Repository;
using Microsoft.EntityFrameworkCore;
using smagAPP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWMonitor.Services
{
    public class DistrictsService : IDistrictsService
    {

        private readonly KWMContext _context;

        public DistrictsService(KWMContext context)
        {
            _context = context;
        }

        public async Task<List<District>> GetAll()
        {
            var DistrictList = await _context.Districts.AsNoTracking().AsQueryable().Include(s => s.Region).ThenInclude(s => s.Country).ToListAsync();
            return DistrictList;
        }

        public async Task<District> Add(District district)
        {
            var result = _context.Districts.Add(district);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<District> GetById(int id)
        {
            return await _context.Districts.Where(p => p.Id == id)
                .Include(s => s.Region)
                .ThenInclude(s => s.Country)
                .FirstOrDefaultAsync();
        }

        public async Task Delete(District district)
        {
            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();
        }

    }
}
