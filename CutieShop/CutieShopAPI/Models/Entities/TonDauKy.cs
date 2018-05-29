using System.Collections.Generic;

namespace CutieShop.API.Models.Entities
{
    public partial class TonDauKy
    {
        public TonDauKy()
        {
            JoinXx = new HashSet<JoinXx>();
        }

        public string IdTdk { get; set; }
        public int? QuantityTdk { get; set; }
        public int? Total { get; set; }

        public ICollection<JoinXx> JoinXx { get; set; }
    }
}
