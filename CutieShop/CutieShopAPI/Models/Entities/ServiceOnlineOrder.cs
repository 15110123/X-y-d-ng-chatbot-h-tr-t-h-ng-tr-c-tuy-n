using System;

namespace CutieShop.API.Models.Entities
{
    public class ServiceOnlineOrder
    {
        public string ServiceOnlineOrderId { get; set; }
        public string PetId { get; set; }
        public DateTime DateBegin { get; set; }

        public OnlineOrder ServiceOnlineOrderNavigation { get; set; }
    }
}
