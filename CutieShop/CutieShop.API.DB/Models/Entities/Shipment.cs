using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Shipment
    {
        public Shipment()
        {
            ShipableGoodofShipments = new HashSet<ShipableGoodofShipment>();
        }

        public string Id { get; set; }
        public string Customer { get; set; }
        public string Shipper { get; set; }
        public DateTime? DateReceived { get; set; }
        public string ShipStatus { get; set; }
        public string AltAddress { get; set; }

        public Customer CustomerNavigation { get; set; }
        public Order IdNavigation { get; set; }
        public ShipStatu ShipStatusNavigation { get; set; }
        public Employee ShipperNavigation { get; set; }
        public ICollection<ShipableGoodofShipment> ShipableGoodofShipments { get; set; }
    }
}
