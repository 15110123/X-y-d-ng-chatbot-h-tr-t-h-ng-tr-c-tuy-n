using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Order
    {
        public Order()
        {
            GoodofOrders = new HashSet<GoodofOrder>();
        }

        public string Id { get; set; }
        public int UsedScore { get; set; }
        public bool IsDeleted { get; set; }

        public ServiceOnlineOrder ServiceOnlineOrder { get; set; }
        public Shipment Shipment { get; set; }
        public ICollection<GoodofOrder> GoodofOrders { get; set; }
    }
}
