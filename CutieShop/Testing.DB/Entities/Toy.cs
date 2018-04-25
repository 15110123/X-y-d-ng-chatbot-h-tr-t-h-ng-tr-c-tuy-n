namespace Testing.DB.Entities
{
    public partial class Toy
    {
        public string ProductId { get; set; }
        public string Color { get; set; }
        public string OriginId { get; set; }
        public string MaterialId { get; set; }

        public Material Material { get; set; }
        public Origin Origin { get; set; }
        public Product Product { get; set; }
    }
}
