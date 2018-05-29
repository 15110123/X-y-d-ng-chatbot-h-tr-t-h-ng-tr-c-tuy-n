using System.Collections.Generic;

namespace CutieShop.Models.Entities
{
    public partial class Status
    {
        public Status()
        {
            OnlineOrder = new HashSet<OnlineOrder>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<OnlineOrder> OnlineOrder { get; set; }
    }
}
