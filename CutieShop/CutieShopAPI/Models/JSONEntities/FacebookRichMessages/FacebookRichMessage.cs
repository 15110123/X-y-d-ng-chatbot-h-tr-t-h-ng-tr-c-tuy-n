
// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.JSONEntities.FacebookRichMessages
{
    internal abstract class FacebookRichMessage
    {
        internal int type { get; set; }
        internal string platform { get; } = "facebook";
    }
}
