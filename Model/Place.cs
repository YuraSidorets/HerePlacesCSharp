using System.Collections.Generic;
using System.Device.Location;
using System.Linq;

using Newtonsoft.Json;

namespace HerePlacesCSharp.Model
{
    public class Place
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "distance")]
        public int Distance { get; set; }

        [JsonProperty(PropertyName = "averageRating")]
        public string AverageRating { get; set; }

        public Category Category { get; set; }

        [JsonProperty(PropertyName = "position")]
        public IList<double> Position { get; set; }

        [JsonProperty(PropertyName = "vicinity")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "href")]
        public string Url { get; set; }

        public GeoCoordinate GeoCoordinates => new GeoCoordinate(this.Position.First(), this.Position.Last());

        public override string ToString()
        {
            return this.Title;
        }
    }
}
