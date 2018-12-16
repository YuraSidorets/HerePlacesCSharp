using HerePlacesCSharp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HerePlacesCSharp
{
    public class PlacesService
    {
        private static string baseUrl = "https://places.cit.api.here.com/places/v1/discover/around";
        private string appId;
        private string appToken;

        public PlacesService(string appId, string appToken)
        {
            this.appId = appId;
            this.appToken = appToken;
        }

        public async Task<List<Place>> ListPlacesAroundLocation(GeoCoordinate coordinate, int radius, string category)
        {
            var rawPlaces = await GetRawPlaces(coordinate, radius, category);
            Response response = JsonConvert.DeserializeObject<Response>(rawPlaces);

            return (from Place p in response.Results.Places
                    orderby p.Distance
                    where p.Position != null
                    select p).ToList(); // Order By Distance
        }

        private Task<string> GetRawPlaces(GeoCoordinate coordinate, int radius, string category)
        {
            var tcs = new TaskCompletionSource<string>();

            var client = new WebClient();
            client.DownloadStringCompleted += (s, e) =>
            {
                if (e.Error == null)
                {
                    tcs.SetResult(e.Result);
                }
                else
                {
                    tcs.SetException(e.Error);
                }
            };

            client.DownloadStringAsync(GetPlaceQuery(coordinate, radius, category));

            return tcs.Task;
        }

        private Uri GetPlaceQuery(GeoCoordinate coordinate, int radius, string category)
        {
            return new Uri($"{baseUrl}?"+
                           $"cat={category}" +
                           $"&in={coordinate.Latitude.ToString(CultureInfo.InvariantCulture)}," + 
                           $"{coordinate.Longitude.ToString(CultureInfo.InvariantCulture)};r={radius}" +
                           $"&app_id={this.appId}" +
                           $"&app_code={appToken}");
        }
    }
}
