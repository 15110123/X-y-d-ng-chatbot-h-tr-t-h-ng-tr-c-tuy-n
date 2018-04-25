
// ReSharper disable InconsistentNaming

namespace Testing.DB.FacebookRichMessages
{
    internal abstract class FacebookRichMessage
    {
        internal int type { get; set; }
        internal string platform { get; } = "facebook";
    }
}
