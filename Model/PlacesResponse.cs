using Newtonsoft.Json;

namespace HerePlacesCSharp.Model
{
    public class PlacesResponse
    {
        [JsonProperty(PropertyName = "results")]
        public Items Results { get; set; }

        [JsonProperty(PropertyName = "next")]
        public string Next { get; set; }

        [JsonProperty(PropertyName = "offset")]
        public int Offset { get; set; }
    }
}
