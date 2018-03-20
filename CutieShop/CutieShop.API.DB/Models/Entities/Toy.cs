using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Toy
    {
        public Toy()
        {
            MaterialofToys = new HashSet<MaterialofToy>();
        }

        public string Id { get; set; }
        public string Color { get; set; }
        public string Region { get; set; }

        public ShipableGood IdNavigation { get; set; }
        public Region RegionNavigation { get; set; }
        public ICollection<MaterialofToy> MaterialofToys { get; set; }
    }
}
