using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Advertisement
    {
        public string Id { get; set; }
        public string ImgUrl { get; set; }
        public string Owner { get; set; }

        public Employee OwnerNavigation { get; set; }
    }
}
