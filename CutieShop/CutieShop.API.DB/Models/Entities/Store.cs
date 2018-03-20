using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Store
    {
        public Store()
        {
            Employees = new HashSet<Employee>();
            Exports = new HashSet<Export>();
            GoodQuantities = new HashSet<GoodQuantity>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsPrimary { get; set; }
        public string Manager { get; set; }
        public bool IsDeleted { get; set; }

        public Employee ManagerNavigation { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Export> Exports { get; set; }
        public ICollection<GoodQuantity> GoodQuantities { get; set; }
    }
}
