using System.Collections.Generic;

namespace CohesiveSoftware.Maps.Implementations.Google
{
    public class RootObject
    {
        public List<Result> results { get; set; } = new List<Result>();
        public string status { get; set; } = string.Empty;
    }

    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; } = string.Empty;
        public Geometry geometry { get; set; } = new Geometry();
        public string place_id { get; set; } = string.Empty;
        public List<string> types { get; set; } = new List<string>();
    }

    public class AddressComponent
    {
        public string long_name { get; set; } = string.Empty;
        public string short_name { get; set; } = string.Empty;
        public List<string> types { get; set; } = new List<string>();
    }

    public class Geometry
    {
        public CoordinateSet bounds { get; set; } = new CoordinateSet();
        public Coordinate location { get; set; } = new Coordinate();
        public string location_type { get; set; } = string.Empty;
        public CoordinateSet viewport { get; set; } = new CoordinateSet();
    }

    public class Coordinate
    {
        public decimal lat { get; set; } = 0;
        public decimal lng { get; set; } = 0;
    }

    public class CoordinateSet
    {
        public Coordinate northeast { get; set; } = new Coordinate();
        public Coordinate southwest { get; set; } = new Coordinate();
    }
}
