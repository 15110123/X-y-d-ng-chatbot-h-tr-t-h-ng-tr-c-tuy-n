using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Accessory
    {
        public Accessory()
        {
            MaterialofAccessories = new HashSet<MaterialofAccessory>();
        }

        public string Id { get; set; }
        public string Color { get; set; }
        public string Smell { get; set; }
        public string Region { get; set; }

        public ShipableGood IdNavigation { get; set; }
        public Region RegionNavigation { get; set; }
        public ICollection<MaterialofAccessory> MaterialofAccessories { get; set; }
    }
}
