namespace CutieShop.API.Models.Entities
{
    public partial class Food
    {
        public string ProductId { get; set; }
        public string NutritionId { get; set; }
        public string OriginId { get; set; }

        public Nutrition Nutrition { get; set; }
        public Origin Origin { get; set; }
        public Product Product { get; set; }
    }
}
