using System;
using System.Collections.Generic;

namespace CutieShop.API.Models.Entities.Models.Entities
{
    public partial class Policy
    {
        public string Name { get; set; }
        public int? MinimumValue { get; set; }
        public int? MaximumValue { get; set; }
    }
}
