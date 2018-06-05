using static System.Text.Encoding;

namespace CutieShop.Models.Utils
{
    public static class TextUtils
    {
        public static bool IsPureAscii(string str) => ASCII.GetString(UTF8.GetBytes(str)) == str;
    }
}
