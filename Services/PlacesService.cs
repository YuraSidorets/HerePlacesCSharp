// TODO: Place Categories, Cuisine Categories 

using HerePlacesCSharp.Model;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace HerePlacesCSharp.Services
{
    public class PlacesService : IPlacesService
    {
        private readonly string baseUrl = "https://places.cit.api.here.com/places/v1";

        private readonly string appId;

        private readonly string appToken;

        public PlacesService(string appId, string appToken)
        {
            this.appId = appId;
            this.appToken = appToken;
        }

        /// <summary>
        /// Find places using a text query.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Sets of places that match a user's search term in a specific location context</returns>
        public async Task<List<Place>> DiscoverSearchPlaces(PlacesRequest request)
        {
            InitServiceParams(request);

            var rawPlaces = await GetRawPlaces(GetPlacesSearchQuery(request, "/discover/search"));
            var response = JsonConvert.DeserializeObject<PlacesResponse>(rawPlaces);

            return response.Results.Places;
        }

        /// <summary>
        /// Find recommended places in a location.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>
        /// The results are confined to those located in the current map view or
        /// search area and are ordered by popularity.
        /// </returns>
        public async Task<List<Place>> DiscoverExplorePlaces(PlacesRequest request)
        {
            InitServiceParams(request);

            var rawPlaces = await GetRawPlaces(GetPlacesSearchQuery(request, "/discover/explore"));
            var response = JsonConvert.DeserializeObject<PlacesResponse>(rawPlaces);

            return response.Results.Places;
        }

        /// <summary>
        /// Find a place by non-Place ID, e.g. PVID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Redirect link to the place resource with context added.</returns>
        public async Task<Place> LookupPlaces(PlacesRequest request)
        {
            InitServiceParams(request);

            var rawPlaces = await GetRawPlaces(GetPlacesSearchQuery(request, "/places/lookup"));
            var response = JsonConvert.DeserializeObject<Place>(rawPlaces);

            return response;
        }

        /// <summary>
        /// Find places with certain categories around a location sorted by distance
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Sets of places within a specific location context sorted by distance.</returns>
        public async Task<List<Place>> BrowsePlaces(PlacesRequest request)
        {
            InitServiceParams(request);

            var rawPlaces = await GetRawPlaces(GetPlacesSearchQuery(request, "/browse"));
            var response = JsonConvert.DeserializeObject<PlacesResponse>(rawPlaces);

            return response.Results.Places;
        }

        /// <summary>
        /// Monitor the availability of the service 
        /// </summary>
        public async void HealthCheck()
        {
            await GetRawPlaces(new Uri($"{baseUrl}/health?app_id={appId}&app_code ={appToken}"));
        }

        private Task<string> GetRawPlaces(Uri uri)
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

            client.DownloadStringAsync(uri);

            return tcs.Task;
        }

        private void InitServiceParams(PlacesRequest request)
        {
            request.AppId = appId;
            request.AppToken = appToken;
        }

        private Uri GetPlacesSearchQuery(PlacesRequest request, string resource)
        {
            return new Uri($"{baseUrl}{resource}{request.GetUriParameterString()}");
        }
    }
}