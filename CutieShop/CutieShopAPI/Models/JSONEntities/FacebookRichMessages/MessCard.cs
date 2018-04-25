// ReSharper disable InconsistentNaming
namespace CutieShop.API.Models.JSONEntities.FacebookRichMessages
{

    public class MessCard
    {
        public int type { get; set; }
        public string platform { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string imageUrl { get; set; }
        public Button[] buttons { get; set; }
    }
}
