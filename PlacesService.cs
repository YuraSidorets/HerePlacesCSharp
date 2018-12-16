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
        private static string baseUrl = "https://places.cit.api.here.com/places/v1/autosuggest";
        private string appId;
        private string appToken;

        public PlacesService(string appId, string appToken)
        {
            this.appId = appId;
            this.appToken = appToken;
        }

        public async Task<List<Place>> ListPlacesAroundLocation(GeoCoordinate coordinate)
        {
            var rawPlaces = await GetRawPlaces(coordinate);
            Response response = JsonConvert.DeserializeObject<Response>(rawPlaces);

            return (from Place p in response.Results.Places
                    orderby p.Distance
                    where p.Position != null
                    select p).ToList(); // Order By Distance
        }

        private Task<string> GetRawPlaces(GeoCoordinate coordinate)
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

            client.DownloadStringAsync(this.GetPlaceQuery(coordinate));

            return tcs.Task;
        }

        private Uri GetPlaceQuery(GeoCoordinate coordinate)
        {
            return new Uri($"{baseUrl}?at=" +
                           $"{coordinate.Latitude.ToString(CultureInfo.InvariantCulture)}," +
                           $"{coordinate.Longitude.ToString(CultureInfo.InvariantCulture)}" +
                           $"&app_id={this.appId}" +
                           $"&app_code={appToken}");
        }
    }
}
