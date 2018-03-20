using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Good
    {
        public Good()
        {
            GoodQuantities = new HashSet<GoodQuantity>();
            GoodofExports = new HashSet<GoodofExport>();
            GoodofImports = new HashSet<GoodofImport>();
            GoodofOrders = new HashSet<GoodofOrder>();
        }

        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public bool IsDeleted { get; set; }

        public Pet Pet { get; set; }
        public Service Service { get; set; }
        public ICollection<GoodQuantity> GoodQuantities { get; set; }
        public ICollection<GoodofExport> GoodofExports { get; set; }
        public ICollection<GoodofImport> GoodofImports { get; set; }
        public ICollection<GoodofOrder> GoodofOrders { get; set; }
    }
}
