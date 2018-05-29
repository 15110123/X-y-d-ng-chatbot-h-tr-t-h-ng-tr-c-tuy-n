using Newtonsoft.Json;

namespace CutieShop.Models.JSONEntities.Vision
{
    public sealed class Color
    {
        [JsonProperty("dominantColorForeground")]
        public string DominantColorForeground { get; set; }

        [JsonProperty("dominantColorBackground")]
        public string DominantColorBackground { get; set; }

        [JsonProperty("dominantColors")]
        public string[] DominantColors { get; set; }

        [JsonProperty("accentColor")]
        public string AccentColor { get; set; }

        [JsonProperty("isBWImg")]
        public bool IsBwImg { get; set; }
    }
}
