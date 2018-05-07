namespace CutieShop.API.Models.Entities
{
    public partial class Cage
    {
        public string ProductId { get; set; }
        public string Color { get; set; }
        public string MaterialId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string OriginId { get; set; }

        public Material Material { get; set; }
        public Origin Origin { get; set; }
        public Product Product { get; set; }
    }
}
