using System.Collections.Generic;

using Newtonsoft.Json;

namespace HerePlacesCSharp.Model
{
    public class Items
    {
        [JsonProperty(PropertyName = "items")]
        public List<Place> Places { get; set; }
    }
}
