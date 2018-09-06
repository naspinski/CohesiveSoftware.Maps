using CohesiveSoftware.Maps.Implementations.Google;
using CohesiveSoftware.Maps.Interfaces;
using Xunit;

namespace CohesiveSoftware.Maps.Tests
{
    public class GoogleMapTests
    {
        IMap map = new GoogleMap(Keys.GoogleMapsApiKey);

        [Fact]
        public void BasicAddress()
        {
            IAddress address = map.GetAddress("212 N 1st St Unit 311, Minneapolis, MN 55401");
            Assert.Equal("Central Minneapolis", address.Neighborhood);
            Assert.Equal("1557", address.PostalCodeSuffix);
        }

        [Fact]
        public void ZipGetsAddress()
        {
            IAddress address = map.GetAddress("55401");
            Assert.Equal("Hennepin County", address.County);
            Assert.Equal("Minneapolis", address.City);
        }

        [Fact]
        public void BadAddress()
        {
            IAddress address = map.GetAddress("alsdjfhaljsdfhalhjsdfalfsdh");
            Assert.Equal("ZERO_RESULTS", address.Status);
        }
    }
}
