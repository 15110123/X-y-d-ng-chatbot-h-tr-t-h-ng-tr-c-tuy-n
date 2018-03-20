using System;
using System.Collections.Generic;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class Conversation
    {
        public string MessageSession { get; set; }
        public bool IsEmployee { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }
        public DateTime SentDate { get; set; }
        public string Id { get; set; }

        public MessageSession MessageSessionNavigation { get; set; }
    }
}
