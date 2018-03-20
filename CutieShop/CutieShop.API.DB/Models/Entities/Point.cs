using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Point
    {
        public string Customer { get; set; }
        public int Value { get; set; }

        public Customer CustomerNavigation { get; set; }
    }
}
