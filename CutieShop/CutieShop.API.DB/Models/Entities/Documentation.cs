using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Documentation
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public string Htmlcontent { get; set; }

        public Employee OwnerNavigation { get; set; }
        public DocType TypeNavigation { get; set; }
    }
}
