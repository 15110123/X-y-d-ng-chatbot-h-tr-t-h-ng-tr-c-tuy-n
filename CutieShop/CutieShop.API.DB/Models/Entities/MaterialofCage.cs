using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class MaterialofCage
    {
        public string Material { get; set; }
        public string Cage { get; set; }

        public Cage CageNavigation { get; set; }
        public Material MaterialNavigation { get; set; }
    }
}
