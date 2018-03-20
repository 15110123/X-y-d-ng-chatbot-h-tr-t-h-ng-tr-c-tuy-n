using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Auth
    {
        public Auth()
        {
            AuthSessions = new HashSet<AuthSession>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public string ProfileImg { get; set; }
        public string Name { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public ICollection<AuthSession> AuthSessions { get; set; }
    }
}
