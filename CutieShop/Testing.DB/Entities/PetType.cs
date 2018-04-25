using System.Collections.Generic;

namespace Testing.DB.Entities
{
    public partial class PetType
    {
        public PetType()
        {
            Pet = new HashSet<Pet>();
            ProductForPetType = new HashSet<ProductForPetType>();
        }

        public string PetTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Pet> Pet { get; set; }
        public ICollection<ProductForPetType> ProductForPetType { get; set; }
    }
}
