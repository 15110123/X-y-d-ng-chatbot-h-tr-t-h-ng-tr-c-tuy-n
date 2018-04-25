// ReSharper disable InconsistentNaming

namespace Testing.DB.FacebookRichMessages
{
    internal sealed class MessCard : FacebookRichMessage
    {
        public sealed class MessCardButton
        {
            internal string text { get; set; }
            internal string postback { get; set; }
            public MessCardButton(string text, string postback)
            {
                this.text = text;
                this.postback = postback;
            }
        }

        internal string title { get; set; }
        internal string subtitle { get; set; }
        internal string imageUrl { get; set; }
        internal MessCardButton[] buttons { get; set; }

        public MessCard(string title, string subtitle, string imageUrl, MessCardButton[] buttons)
        {
            type = 1;
            this.title = title;
            this.subtitle = subtitle;
            this.imageUrl = imageUrl;
            this.buttons = buttons;
        }
    }
}
