using Newtonsoft.Json;

namespace HerePlacesCSharp.Model
{
    public class Category
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
