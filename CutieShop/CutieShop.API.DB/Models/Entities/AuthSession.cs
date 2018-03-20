using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class AuthSession
    {
        public string Id { get; set; }
        public string Auth { get; set; }
        public bool IsDeleted { get; set; }

        public Auth AuthNavigation { get; set; }
    }
}
