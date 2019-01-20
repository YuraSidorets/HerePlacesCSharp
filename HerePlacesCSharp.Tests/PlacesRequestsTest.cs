// TODO: Mock places service 

using HerePlacesCSharp.Model;
using HerePlacesCSharp.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HerePlacesCSharp.Tests
{
    [TestClass]
    public class PlacesRequestsTest
    {
        private PlacesService placesService = new PlacesService("api key", "api token");

        [TestMethod]
        public void DiscoverSearchPlacesFound()
        {
            var request = new PlacesRequest { Q = "antipodes", At = "52.531,13.3843" };

            var response = placesService.DiscoverSearchPlaces(request).Result;
            Assert.IsTrue(response.Count > 0);
        }

        [TestMethod]
        public void DiscoverExplorePlacesFound()
        {
            var request = new PlacesRequest { At = "52.531,13.3843" };

            var response = placesService.DiscoverExplorePlaces(request).Result;
            Assert.IsTrue(response.Count > 0);
        }

        [TestMethod]
        public void LookupPlacesFound()
        {
            var request = new PlacesRequest { Source = "sharing", PlaceId = "276u33db-bae64cc3795443a381643b996f02a2a5" };

            var response = placesService.LookupPlaces(request).Result;
            Assert.IsTrue(response != null);
        }

        [TestMethod]
        public void BrowsePlacesFound()
        {
            var request = new PlacesRequest { At = "52.531,13.3843" };

            var response = placesService.BrowsePlaces(request).Result;
            Assert.IsTrue(response.Count > 0);
        }

        [TestMethod]
        public void HealthCheck()
        {
            placesService.HealthCheck();
        }
    }
}