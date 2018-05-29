using System.Collections.Generic;

namespace CutieShop.Models.Entities
{
    public partial class Vendor
    {
        public Vendor()
        {
            Product = new HashSet<Product>();
        }

        public string VendorId { get; set; }
        public string VendorName { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
