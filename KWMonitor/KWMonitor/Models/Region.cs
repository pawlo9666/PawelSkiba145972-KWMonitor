namespace KoronaWirusMonitor3.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
    }
}
