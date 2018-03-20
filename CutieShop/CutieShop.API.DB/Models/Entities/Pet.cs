using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Pet
    {
        public Pet()
        {
            Services = new HashSet<Service>();
        }

        public string Id { get; set; }
        public string Size { get; set; }
        public int Longevity { get; set; }
        public int MaxBornChild { get; set; }
        public bool IsFurDrop { get; set; }
        public string FeedingRoutine { get; set; }
        public string Type { get; set; }

        public FeedingRoutine FeedingRoutineNavigation { get; set; }
        public Good IdNavigation { get; set; }
        public PetSize SizeNavigation { get; set; }
        public PetType TypeNavigation { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
