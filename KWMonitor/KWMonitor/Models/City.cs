using System.Data;

namespace KoronaWirusMonitor3.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public District District { get; set; }
        public int DistrictId { get; set; } 
    }
}
