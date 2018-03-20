using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Advertisements = new HashSet<Advertisement>();
            Documentations = new HashSet<Documentation>();
            Exports = new HashSet<Export>();
            Imports = new HashSet<Import>();
            MessageSessions = new HashSet<MessageSession>();
            Posts = new HashSet<Post>();
            Shipments = new HashSet<Shipment>();
            Stores = new HashSet<Store>();
        }

        public string Id { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HomeTown { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Store { get; set; }

        public Auth IdNavigation { get; set; }
        public Store StoreNavigation { get; set; }
        public EmpType TypeNavigation { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
        public ICollection<Documentation> Documentations { get; set; }
        public ICollection<Export> Exports { get; set; }
        public ICollection<Import> Imports { get; set; }
        public ICollection<MessageSession> MessageSessions { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Shipment> Shipments { get; set; }
        public ICollection<Store> Stores { get; set; }
    }
}
