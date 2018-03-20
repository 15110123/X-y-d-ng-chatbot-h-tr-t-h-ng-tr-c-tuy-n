using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class ShipableGood
    {
        public ShipableGood()
        {
            ShipableGoodofShipments = new HashSet<ShipableGoodofShipment>();
        }

        public string Id { get; set; }

        public Accessory Accessory { get; set; }
        public Cage Cage { get; set; }
        public Food Food { get; set; }
        public Toy Toy { get; set; }
        public ICollection<ShipableGoodofShipment> ShipableGoodofShipments { get; set; }
    }
}
