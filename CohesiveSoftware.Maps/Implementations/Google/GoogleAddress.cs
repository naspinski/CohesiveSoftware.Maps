using CohesiveSoftware.Maps.Interfaces;
using CohesiveSoftware.Maps.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace CohesiveSoftware.Maps.Implementations.Google
{
    public class GoogleAddress : IAddress
    {
        private readonly RootObject _root;
        private Result _results { get { return _root?.results?.FirstOrDefault() ?? new Result(); } }

        public string StreetNumber { get { return GetAddressComponent("street_number").long_name; } }
        public string Street { get { return GetAddressComponent("route").long_name; } }

        public string ApartmentNumber { get { return GetAddressComponent("subpremise").long_name; } }

        public string City { get { return GetAddressComponent("political", "locality").long_name; } }

        public string Neighborhood { get { return GetAddressComponent("political", "neighborhood").long_name; } }

        public string County { get { return GetAddressComponent("political", "administrative_area_level_2").long_name; } }

        public string PostalCode { get { return GetAddressComponent("postal_code")?.long_name ?? string.Empty; } }

        public string PostalCodeSuffix { get { return GetAddressComponent("postal_code_suffix")?.long_name ?? string.Empty; } }

        public string FormattedAddress { get { return _results.formatted_address; } }

        public Territory State { get { return GetTerritory("administrative_area_level_1"); } }

        public Territory Country { get { return GetTerritory("country"); } }

        public string LocationType { get { return _results.geometry?.location_type ?? string.Empty; } }
        public Coordinates Location
        {
            get
            {
                return _results.geometry == null || _results.geometry.location == null ? new Coordinates()
                    : new Coordinates("location", _results.geometry.location.lat, _results.geometry.location.lng);
            }
        }

        public List<Coordinates> Bounds { get { return GetCoordinatesFromSet(_results.geometry?.bounds ?? null); } }

        public List<Coordinates> ViewPort { get { return GetCoordinatesFromSet(_results.geometry?.viewport ?? null); } }
        public string Status { get { return _root?.status ?? string.Empty; } }


        private AddressComponent GetAddressComponent(params string[] types)
        {
            types = types.Select(x => x.ToLower()).Distinct().ToArray();
            return _results.address_components?
                .FirstOrDefault(x => types.All(t => x.types.Select(y => y.ToLower()).Contains(t))) ?? new AddressComponent();
        }

        private Territory GetTerritory(string type)
        {
            var ap = GetAddressComponent("political", type);
            return new Territory(ap.long_name, ap.short_name);
        }

        private List<Coordinates> GetCoordinatesFromSet(CoordinateSet coordinateSet)
        {
            var coords = new List<Coordinates>();
            var ne = coordinateSet?.northeast ?? new Coordinate();
            var sw = coordinateSet?.southwest ?? new Coordinate();
            coords.Add(new Coordinates("northeast", ne.lat, ne.lng));
            coords.Add(new Coordinates("southwest", sw.lat, sw.lng));
            return coords;
        }

        public GoogleAddress(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    var serializer = new JsonSerializer();
                    using (var sr = new StreamReader(stream))
                    {
                        using (var jsonTextReader = new JsonTextReader(sr))
                        {
                            _root = serializer.Deserialize<RootObject>(jsonTextReader);
                        }
                    }
                }
            }
        }
    }
}
