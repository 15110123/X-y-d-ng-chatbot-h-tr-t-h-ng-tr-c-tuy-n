using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class EmpType
    {
        public EmpType()
        {
            Employees = new HashSet<Employee>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
