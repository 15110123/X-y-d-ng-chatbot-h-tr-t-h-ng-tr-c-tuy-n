//ReSharper disable All

namespace CutieShop.Models.JSONEntities.Settings
{
    public sealed class APISettings
    {
        public Url Url { get; set; }
    }

    public sealed class Url
    {
        public string MainUrl { get; set; }
        public string DbUrl { get; set; }
    }
}
