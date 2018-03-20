using Newtonsoft.Json;

namespace CutieShop.API.Models.JSONEntities.Vision
{
    public sealed class Category
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }
    }
}
