using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Import
    {
        public Import()
        {
            GoodofImports = new HashSet<GoodofImport>();
        }

        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Employee { get; set; }
        public bool IsDeleted { get; set; }
        public string ImporterName { get; set; }

        public Employee EmployeeNavigation { get; set; }
        public ICollection<GoodofImport> GoodofImports { get; set; }
    }
}
