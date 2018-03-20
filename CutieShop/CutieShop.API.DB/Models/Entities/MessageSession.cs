using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class MessageSession
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string Customer { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        public Customer CustomerNavigation { get; set; }
        public Employee EmployeeNavigation { get; set; }
        public Conversation Conversation { get; set; }
    }
}
