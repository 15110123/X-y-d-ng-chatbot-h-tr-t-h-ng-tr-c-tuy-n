using System;
using System.Collections.Generic;

namespace CutieShop.Models.Entities
{
    public partial class Report
    {
        public Report()
        {
            JoinXx = new HashSet<JoinXx>();
        }

        public string IdReport { get; set; }
        public DateTime? DateElWarehouse { get; set; }

        public ICollection<JoinXx> JoinXx { get; set; }
    }
}
