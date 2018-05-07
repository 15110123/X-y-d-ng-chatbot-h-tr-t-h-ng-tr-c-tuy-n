using System.Collections.Generic;

namespace CutieShop.API.Models.Entities
{
    public partial class Nutrition
    {
        public Nutrition()
        {
            Food = new HashSet<Food>();
        }

        public string NutritionId { get; set; }
        public string Name { get; set; }

        public ICollection<Food> Food { get; set; }
    }
}
