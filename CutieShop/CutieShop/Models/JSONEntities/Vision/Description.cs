using Newtonsoft.Json;

namespace CutieShop.Models.JSONEntities.Vision
{
    public sealed class Description
    {
        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("captions")]
        public Caption[] Captions { get; set; }
    }
}
