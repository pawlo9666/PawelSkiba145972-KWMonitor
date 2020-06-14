using KoronaWirusMonitor3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWMonitor.Models
{
    public class RegionDTO
    {
        public string Name { get; set; }
        public virtual CountryDTO Country { get; set; }
    }
}
