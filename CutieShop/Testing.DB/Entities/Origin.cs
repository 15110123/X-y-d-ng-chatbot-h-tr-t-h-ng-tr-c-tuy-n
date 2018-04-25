using System.Collections.Generic;

namespace Testing.DB.Entities
{
    public partial class Origin
    {
        public Origin()
        {
            Accessory = new HashSet<Accessory>();
            Cage = new HashSet<Cage>();
            Food = new HashSet<Food>();
            Toy = new HashSet<Toy>();
        }

        public string OriginId { get; set; }
        public string Name { get; set; }

        public ICollection<Accessory> Accessory { get; set; }
        public ICollection<Cage> Cage { get; set; }
        public ICollection<Food> Food { get; set; }
        public ICollection<Toy> Toy { get; set; }
    }
}
