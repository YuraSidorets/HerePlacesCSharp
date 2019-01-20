using Newtonsoft.Json;

namespace HerePlacesCSharp.Model
{
    public class PlacesLookupResponse
    {
        [JsonProperty(PropertyName = "href")]
        public string Href { get; set; }
    }
}