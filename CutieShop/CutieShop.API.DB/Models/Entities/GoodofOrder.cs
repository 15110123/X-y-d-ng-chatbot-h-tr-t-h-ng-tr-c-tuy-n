using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class GoodofOrder
    {
        public string Good { get; set; }
        public string Order { get; set; }

        public Good GoodNavigation { get; set; }
        public Order OrderNavigation { get; set; }
    }
}
