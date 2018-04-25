using System.Collections.Generic;

namespace Testing.DB.Entities
{
    public partial class Product
    {
        public Product()
        {
            OnlineOrderProduct = new HashSet<OnlineOrderProduct>();
            ProductForPetType = new HashSet<ProductForPetType>();
        }

        public string ProductId { get; set; }
        public string ImgUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string VendorId { get; set; }

        public Vendor Vendor { get; set; }
        public Accessory Accessory { get; set; }
        public Cage Cage { get; set; }
        public Food Food { get; set; }
        public Pet Pet { get; set; }
        public Service Service { get; set; }
        public Toy Toy { get; set; }
        public ICollection<OnlineOrderProduct> OnlineOrderProduct { get; set; }
        public ICollection<ProductForPetType> ProductForPetType { get; set; }
    }
}
