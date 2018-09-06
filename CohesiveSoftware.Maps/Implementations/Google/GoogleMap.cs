using CohesiveSoftware.Maps.Interfaces;

namespace CohesiveSoftware.Maps.Implementations.Google
{
    public class GoogleMap : IMap
    {
        private readonly string _googleMapsApiKey;
        private const string _apiRoot = "https://maps.googleapis.com/maps/api/geocode/";

        public GoogleMap(string googleMapsApiKey)
        {
            _googleMapsApiKey = googleMapsApiKey;
        }

        public IAddress GetAddress(string address)
        {
            var url = $"{_apiRoot}json?address={address}&key={_googleMapsApiKey}";
            return new GoogleAddress(url);
        }
    }
}
