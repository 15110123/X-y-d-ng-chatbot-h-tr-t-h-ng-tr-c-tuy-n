namespace CutieShop.Models.Entities
{
    public partial class Pet
    {
        public string ProductId { get; set; }
        public string SizeId { get; set; }
        public int LifeSpan { get; set; }
        public int CubQuantity { get; set; }
        public bool IsFurDrop { get; set; }
        public int EatingRoutine { get; set; }
        public string PetTypeId { get; set; }

        public PetType PetType { get; set; }
        public Product Product { get; set; }
        public Size Size { get; set; }
    }
}
