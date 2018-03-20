using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Nutrition
    {
        public Nutrition()
        {
            NutritionofFoods = new HashSet<NutritionofFood>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<NutritionofFood> NutritionofFoods { get; set; }
    }
}
