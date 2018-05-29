using System.Collections.Generic;

namespace CutieShop.API.Models.Entities
{
    public partial class NhapTrongKy
    {
        public NhapTrongKy()
        {
            JoinXx = new HashSet<JoinXx>();
        }

        public string IdNtk { get; set; }
        public int? QuantityNtk { get; set; }
        public int? Total { get; set; }

        public ICollection<JoinXx> JoinXx { get; set; }
    }
}
