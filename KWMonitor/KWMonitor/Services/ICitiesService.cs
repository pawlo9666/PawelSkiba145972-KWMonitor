using KoronaWirusMonitor3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWMonitor.Services
{
    public interface ICitiesService
    {
        Task<City> Add(City city);
        Task<List<City>> GetAll();
        Task<City> GetById(int id);
        Task Delete(City City);
    }
}