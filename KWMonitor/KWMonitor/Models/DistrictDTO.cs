using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWMonitor.Models
{
    public class DistrictDTO
    {
        public string Name { get; set; }
        public virtual RegionDTO Region { get; set; }
    }
}
