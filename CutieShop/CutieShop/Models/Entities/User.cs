using System;
using System.Collections.Generic;

namespace CutieShop.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Invoice = new HashSet<Invoice>();
            OnlineOrder = new HashSet<OnlineOrder>();
            UserPointHistory = new HashSet<UserPointHistory>();
        }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string FacebookId { get; set; }

        public Auth UsernameNavigation { get; set; }
        public UserPoint UserPoint { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
        public ICollection<OnlineOrder> OnlineOrder { get; set; }
        public ICollection<UserPointHistory> UserPointHistory { get; set; }
    }
}
