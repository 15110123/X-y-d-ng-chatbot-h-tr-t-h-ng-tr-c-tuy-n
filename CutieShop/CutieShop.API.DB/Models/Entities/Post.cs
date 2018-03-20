using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Post
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string VidUrl { get; set; }
        public bool IsDeleted { get; set; }

        public Employee EmployeeNavigation { get; set; }
    }
}
