using System.Collections.Generic;

namespace CutieShop.API.Models.Entities
{
    public class Size
    {
        public Size()
        {
            Pet = new HashSet<Pet>();
        }

        public string SizeId { get; set; }
        public string Name { get; set; }

        public ICollection<Pet> Pet { get; set; }
    }
}
