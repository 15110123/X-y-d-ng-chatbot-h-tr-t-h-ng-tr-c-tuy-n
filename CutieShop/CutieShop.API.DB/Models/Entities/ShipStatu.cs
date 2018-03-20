using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class ShipStatu
    {
        public ShipStatu()
        {
            Shipments = new HashSet<Shipment>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Shipment> Shipments { get; set; }
    }
}
