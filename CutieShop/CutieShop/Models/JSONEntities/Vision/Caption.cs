using Newtonsoft.Json;

namespace CutieShop.Models.JSONEntities.Vision
{
    public sealed class Caption
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }
}
