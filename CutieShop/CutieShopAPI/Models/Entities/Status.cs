using System;
using System.Collections.Generic;

namespace CutieShop.API.Models.Entities.Models.Entities
{
    public partial class Status
    {
        public Status()
        {
            OnlineOrder = new HashSet<OnlineOrder>();
        }

        public string StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<OnlineOrder> OnlineOrder { get; set; }
    }
}
