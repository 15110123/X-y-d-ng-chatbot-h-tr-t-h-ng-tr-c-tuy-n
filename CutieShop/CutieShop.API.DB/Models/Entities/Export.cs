using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Export
    {
        public Export()
        {
            GoodofExports = new HashSet<GoodofExport>();
        }

        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Employee { get; set; }
        public string Store { get; set; }
        public bool IsDeleted { get; set; }

        public Employee EmployeeNavigation { get; set; }
        public Store StoreNavigation { get; set; }
        public ICollection<GoodofExport> GoodofExports { get; set; }
    }
}
