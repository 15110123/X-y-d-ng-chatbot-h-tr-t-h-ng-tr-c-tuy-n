using System;
using System.Collections.Generic;

namespace CutieShop
{
    public partial class XuatTrongKy
    {
        public XuatTrongKy()
        {
            JoinXx = new HashSet<JoinXx>();
        }

        public string IdXtk { get; set; }
        public int? QuantityXtk { get; set; }
        public int? Total { get; set; }
        public int? PriceExport { get; set; }

        public ICollection<JoinXx> JoinXx { get; set; }
    }
}
