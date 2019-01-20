using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using HerePlacesCSharp.Model;

namespace HerePlacesCSharp.Services
{
    public interface IPlacesService
    {
        Task<List<Place>> DiscoverSearchPlaces(PlacesRequest request);

        Task<List<Place>> DiscoverExplorePlaces(PlacesRequest request);

        Task<Place> LookupPlaces(PlacesRequest request);

        Task<List<Place>> BrowsePlaces(PlacesRequest request);

        void HealthCheck();
    }
}
