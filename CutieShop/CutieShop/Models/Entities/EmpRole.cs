using System.Collections.Generic;

namespace CutieShop.Models.Entities
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
