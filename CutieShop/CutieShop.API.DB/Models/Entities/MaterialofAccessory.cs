using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class MaterialofAccessory
    {
        public string Material { get; set; }
        public string Accessory { get; set; }

        public Accessory AccessoryNavigation { get; set; }
        public Material MaterialNavigation { get; set; }
    }
}
