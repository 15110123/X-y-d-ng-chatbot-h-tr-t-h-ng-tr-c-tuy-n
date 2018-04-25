namespace Testing.DB.Entities
{
    public partial class ProductForPetType
    {
        public string ProductId { get; set; }
        public string PetTypeId { get; set; }

        public PetType PetType { get; set; }
        public Product Product { get; set; }
    }
}
