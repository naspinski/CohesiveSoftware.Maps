namespace CohesiveSoftware.Maps.Models
{
    public class Coordinates
    {
        public string Name { get; set; } = string.Empty;
        public decimal Latitude { get; set; } = 0;
        public decimal Longitude { get; set; } = 0;

        public Coordinates() { }
        public Coordinates(string name, decimal latitude, decimal longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
