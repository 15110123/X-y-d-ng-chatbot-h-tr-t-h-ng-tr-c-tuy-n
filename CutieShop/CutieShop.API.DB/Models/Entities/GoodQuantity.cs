using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class GoodQuantity
    {
        public string Good { get; set; }
        public string Store { get; set; }
        public int Quantity { get; set; }

        public Good GoodNavigation { get; set; }
        public Store StoreNavigation { get; set; }
    }
}
