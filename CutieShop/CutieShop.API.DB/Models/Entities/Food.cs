using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Food
    {
        public Food()
        {
            NutritionofFoods = new HashSet<NutritionofFood>();
        }

        public string Id { get; set; }
        public string Region { get; set; }

        public ShipableGood IdNavigation { get; set; }
        public Region RegionNavigation { get; set; }
        public ICollection<NutritionofFood> NutritionofFoods { get; set; }
    }
}
