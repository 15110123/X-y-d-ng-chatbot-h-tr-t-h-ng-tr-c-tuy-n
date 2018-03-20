using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class DocType
    {
        public DocType()
        {
            Documentations = new HashSet<Documentation>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Documentation> Documentations { get; set; }
    }
}
