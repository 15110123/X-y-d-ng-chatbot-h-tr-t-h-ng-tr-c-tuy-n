using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class FeedingRoutine
    {
        public FeedingRoutine()
        {
            Pets = new HashSet<Pet>();
        }

        public string Id { get; set; }
        public int FrequencyPerDay { get; set; }

        public ICollection<Pet> Pets { get; set; }
    }
}
