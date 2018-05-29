namespace CutieShop.API.Models.Entities
{
    public partial class Accessory
    {
        public string ProductId { get; set; }
        public string Color { get; set; }
        public string Smell { get; set; }
        public string OriginId { get; set; }
        public string MaterialId { get; set; }

        public Material Material { get; set; }
        public Origin Origin { get; set; }
        public Product Product { get; set; }
    }
}
