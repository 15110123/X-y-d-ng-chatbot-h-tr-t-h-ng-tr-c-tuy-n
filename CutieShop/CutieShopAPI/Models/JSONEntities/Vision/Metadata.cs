using Newtonsoft.Json;

namespace CutieShop.API.Models.JSONEntities.Vision
{
    public sealed class Metadata
    {
        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }
    }
}
