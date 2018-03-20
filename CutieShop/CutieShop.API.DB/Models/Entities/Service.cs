using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Service
    {
        public Service()
        {
            ServiceOnlineOrders = new HashSet<ServiceOnlineOrder>();
        }

        public string Id { get; set; }
        public string Pet { get; set; }

        public Good IdNavigation { get; set; }
        public Pet PetNavigation { get; set; }
        public ICollection<ServiceOnlineOrder> ServiceOnlineOrders { get; set; }
    }
}
