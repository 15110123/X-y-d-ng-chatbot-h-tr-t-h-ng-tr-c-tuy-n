using Newtonsoft.Json;

namespace CutieShop.API.Models.JSONEntities.Vision
{
    public sealed class VisionResult
    {
        [JsonProperty("categories")]
        public Category[] Categories { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("color")]
        public Color Color { get; set; }
    }
}
