namespace Testing.DB.Entities
{
    public partial class Policy
    {
        public string Name { get; set; }
        public int? MinimumValue { get; set; }
        public int? MaximumValue { get; set; }
    }
}
