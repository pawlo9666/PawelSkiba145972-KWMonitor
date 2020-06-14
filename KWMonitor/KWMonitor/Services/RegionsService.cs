using KoronaWirusMonitor3.Models;
using KoronaWirusMonitor3.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWMonitor.Services
{
    public class RegionsService : IRegionsService
    {

        private readonly KWMContext _context;

        public RegionsService(KWMContext context)
        {
            _context = context;
        }

        public async Task<List<Region>> GetAll()
        {
            var RegionList = await _context.Regions.AsNoTracking().AsQueryable().Include(s => s.Country).ToListAsync();
            return RegionList;
        }

        public async Task<Region> Add(Region Region)
        {
            var result = _context.Regions.Add(Region);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Region> GetById(int id)
        {
            return await _context.Regions.Where(p => p.Id == id)
                .Include(s => s.Country)
                .FirstOrDefaultAsync();
        }

        public async Task Delete(Region region)
        {
            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
        }

    }
}
