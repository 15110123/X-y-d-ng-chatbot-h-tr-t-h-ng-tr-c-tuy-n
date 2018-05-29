using System;
using System.Collections.Generic;

namespace CutieShop
{
    public partial class Service
    {
        public string ProductId { get; set; }
        public int StartDayOfWeek { get; set; }
        public int EndDayOfWeek { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }

        public Product Product { get; set; }
    }
}
