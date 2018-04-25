using System.Collections.Generic;

namespace Testing.DB.Entities
{
    public partial class Auth
    {
        public Auth()
        {
            Session = new HashSet<Session>();
        }

        public string Password { get; set; }
        public string Username { get; set; }

        public Employee Employee { get; set; }
        public User User { get; set; }
        public ICollection<Session> Session { get; set; }
    }
}
