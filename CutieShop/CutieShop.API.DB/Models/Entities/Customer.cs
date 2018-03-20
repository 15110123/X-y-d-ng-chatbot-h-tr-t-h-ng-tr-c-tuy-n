using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            MessageSessions = new HashSet<MessageSession>();
            Shipments = new HashSet<Shipment>();
        }

        public string Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Auth IdNavigation { get; set; }
        public Point Point { get; set; }
        public ICollection<MessageSession> MessageSessions { get; set; }
        public ICollection<Shipment> Shipments { get; set; }
    }
}
