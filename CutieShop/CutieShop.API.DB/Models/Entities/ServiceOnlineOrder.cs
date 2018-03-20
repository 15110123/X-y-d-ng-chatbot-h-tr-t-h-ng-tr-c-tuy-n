using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class ServiceOnlineOrder
    {
        public string Id { get; set; }
        public string Service { get; set; }
        public DateTime DateStart { get; set; }
        public string TicketId { get; set; }

        public Order IdNavigation { get; set; }
        public Service ServiceNavigation { get; set; }
    }
}
