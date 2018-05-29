using System;
using System.Collections.Generic;

namespace CutieShop.API.Models.Entities
{
    public partial class OnlineOrder
    {
        public OnlineOrder()
        {
            OnlineOrderProduct = new HashSet<OnlineOrderProduct>();
        }

        public string OnlineOrderId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Username { get; set; }
        public int StatusId { get; set; }

        public Status Status { get; set; }
        public User UsernameNavigation { get; set; }
        public ServiceOnlineOrder ServiceOnlineOrder { get; set; }
        public ICollection<OnlineOrderProduct> OnlineOrderProduct { get; set; }
    }
}
