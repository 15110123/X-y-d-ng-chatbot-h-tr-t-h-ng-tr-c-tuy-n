using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class PetType
    {
        public PetType()
        {
            Pets = new HashSet<Pet>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; }
    }
}
