using System.Collections.Generic;

namespace CutieShop.Models.Entities
{
    public partial class Material
    {
        public Material()
        {
            Accessory = new HashSet<Accessory>();
            Cage = new HashSet<Cage>();
            Toy = new HashSet<Toy>();
        }

        public string MaterialId { get; set; }
        public string Name { get; set; }

        public ICollection<Accessory> Accessory { get; set; }
        public ICollection<Cage> Cage { get; set; }
        public ICollection<Toy> Toy { get; set; }
    }
}
