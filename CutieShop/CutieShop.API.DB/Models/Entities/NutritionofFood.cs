using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class NutritionofFood
    {
        public string Nutrition { get; set; }
        public string Food { get; set; }

        public Food FoodNavigation { get; set; }
        public Nutrition NutritionNavigation { get; set; }
    }
}
