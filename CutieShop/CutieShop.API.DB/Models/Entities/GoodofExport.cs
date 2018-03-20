using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class GoodofExport
    {
        public string Good { get; set; }
        public string Export { get; set; }
        public int ExportQuantity { get; set; }
        public int RealQuantity { get; set; }

        public Export ExportNavigation { get; set; }
        public Good GoodNavigation { get; set; }
    }
}
