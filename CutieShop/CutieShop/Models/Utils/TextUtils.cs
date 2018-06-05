using static System.Text.Encoding;

namespace CutieShop.Models.Utils
{
    public static class TextUtils
    {
        public static bool IsPureAscii(string str) => ASCII.GetString(UTF8.GetBytes(str)) == str;

        public static string FirstName(this string str) =>
            str.Substring(str.IndexOf(' ') + 1);

        public static string LastName(this string str) => str.Substring(0, str.IndexOf(' '));
    }
}
