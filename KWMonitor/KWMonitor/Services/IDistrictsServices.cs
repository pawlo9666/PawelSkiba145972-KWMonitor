using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoronaWirusMonitor3.Models;
using Microsoft.AspNetCore.Mvc;

namespace smagAPP.Services
{
    public interface IDistrictsService
    {
        Task<District> Add(District district);
        Task<List<District>> GetAll();
        Task<District> GetById(int id);
        Task Delete(District district);
    }
}
