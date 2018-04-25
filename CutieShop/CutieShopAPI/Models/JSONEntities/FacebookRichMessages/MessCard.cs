// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.JSONEntities.FacebookRichMessages
{
    internal sealed class MessCard : FacebookRichMessage
    {
        public sealed class MessCardButton
        {
            internal string text { get; set; }
            internal string postback { get; set; }
        }

        internal string title { get; set; }
        internal string subtitle { get; set; }
        internal string imageUrl { get; set; }
        internal MessCardButton[] buttons { get; set; }

        public MessCard(string title, string subtitle, string imageUrl, MessCardButton[] buttons)
        {
            this.title = title;
            this.subtitle = subtitle;
            this.imageUrl = imageUrl;
            this.buttons = buttons;
        }
    }
}
