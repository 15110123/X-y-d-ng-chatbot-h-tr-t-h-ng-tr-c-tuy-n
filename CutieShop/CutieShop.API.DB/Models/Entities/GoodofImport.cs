using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class GoodofImport
    {
        public string Import { get; set; }
        public string Good { get; set; }
        public int ImportQuantity { get; set; }
        public int ImportPrice { get; set; }
        public int RealQuantity { get; set; }

        public Good GoodNavigation { get; set; }
        public Import ImportNavigation { get; set; }
    }
}
