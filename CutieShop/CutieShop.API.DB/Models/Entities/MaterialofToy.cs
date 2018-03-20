using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class MaterialofToy
    {
        public string Material { get; set; }
        public string Toy { get; set; }

        public Material MaterialNavigation { get; set; }
        public Toy ToyNavigation { get; set; }
    }
}
