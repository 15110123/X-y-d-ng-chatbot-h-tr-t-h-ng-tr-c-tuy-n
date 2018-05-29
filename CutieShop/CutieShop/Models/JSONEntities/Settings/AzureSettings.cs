namespace CutieShop.Models.JSONEntities.Settings
{
    public sealed class AzureSettings
    {
        public Vision Vision { get; set; }
    }

    public sealed class Vision
    {
        public string Endpoint { get; set; }
        public string Key1 { get; set; }
        public string Key2 { get; set; }
    }
}
