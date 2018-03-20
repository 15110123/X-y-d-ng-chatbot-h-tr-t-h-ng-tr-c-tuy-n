using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Cage
    {
        public Cage()
        {
            MaterialofCages = new HashSet<MaterialofCage>();
        }

        public string Id { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public string Region { get; set; }

        public ShipableGood IdNavigation { get; set; }
        public Region RegionNavigation { get; set; }
        public ICollection<MaterialofCage> MaterialofCages { get; set; }
    }
}
