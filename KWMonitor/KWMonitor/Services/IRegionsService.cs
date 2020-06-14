using KoronaWirusMonitor3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWMonitor.Services
{
    public interface IRegionsService
    {
        Task<Region> Add(Region region);
        Task<List<Region>> GetAll();
        Task<Region> GetById(int id);
        Task Delete(Region Region);
    }
}