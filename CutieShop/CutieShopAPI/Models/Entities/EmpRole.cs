using System.Collections.Generic;

namespace CutieShop.API.Models.Entities
{
    public partial class EmpRole
    {
        public EmpRole()
        {
            Employee = new HashSet<Employee>();
        }

        public string RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
