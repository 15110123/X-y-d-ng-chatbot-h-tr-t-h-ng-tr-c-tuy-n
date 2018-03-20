using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class ShipableGoodofShipment
    {
        public string ShipableGood { get; set; }
        public string Shipment { get; set; }

        public ShipableGood ShipableGoodNavigation { get; set; }
        public Shipment ShipmentNavigation { get; set; }
    }
}
