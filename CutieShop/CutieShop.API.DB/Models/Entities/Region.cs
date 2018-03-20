using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Region
    {
        public Region()
        {
            Accessories = new HashSet<Accessory>();
            Cages = new HashSet<Cage>();
            Foods = new HashSet<Food>();
            Toys = new HashSet<Toy>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Accessory> Accessories { get; set; }
        public ICollection<Cage> Cages { get; set; }
        public ICollection<Food> Foods { get; set; }
        public ICollection<Toy> Toys { get; set; }
    }
}
