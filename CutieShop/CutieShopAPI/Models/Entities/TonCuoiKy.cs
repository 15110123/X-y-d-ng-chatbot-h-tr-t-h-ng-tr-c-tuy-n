using System;
using System.Collections.Generic;

namespace CutieShop
{
    public partial class TonCuoiKy
    {
        public TonCuoiKy()
        {
            JoinXx = new HashSet<JoinXx>();
        }

        public string IdTck { get; set; }
        public int? QuantityTck { get; set; }
        public int? Total { get; set; }

        public ICollection<JoinXx> JoinXx { get; set; }
    }
}
