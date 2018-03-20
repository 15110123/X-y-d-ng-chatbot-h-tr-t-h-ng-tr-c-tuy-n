using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Material
    {
        public Material()
        {
            MaterialofAccessories = new HashSet<MaterialofAccessory>();
            MaterialofCages = new HashSet<MaterialofCage>();
            MaterialofToys = new HashSet<MaterialofToy>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<MaterialofAccessory> MaterialofAccessories { get; set; }
        public ICollection<MaterialofCage> MaterialofCages { get; set; }
        public ICollection<MaterialofToy> MaterialofToys { get; set; }
    }
}
