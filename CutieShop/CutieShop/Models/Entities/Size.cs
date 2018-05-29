using System.Collections.Generic;

namespace CutieShop.Models.Entities
{
    public partial class Size
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
