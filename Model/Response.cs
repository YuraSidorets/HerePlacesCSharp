using Newtonsoft.Json;

namespace HerePlacesCSharp.Model
{
    public class Response
    {
        [JsonProperty(PropertyName = "results")]
        public Items Results { get; set; }
    }
}
