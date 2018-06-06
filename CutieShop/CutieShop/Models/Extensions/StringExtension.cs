using System;
using System.Linq;
using System.Text;

namespace CutieShop.Models.Extensions
{
    public static class StringExtension
    {
        public static bool IsPureAscii(this string str) => Encoding.ASCII.GetString(Encoding.UTF8.GetBytes(str)) == str;

        public static string FirstName(this string str) =>
            str.Substring(str.IndexOf(' ') + 1);

        public static string LastName(this string str) => str.Substring(0, str.IndexOf(' '));

        public static string MultiReplace(this string src, params (string oldVal, string newVal)[] valTuple) => valTuple.Aggregate(src, (cur, ele) => cur.Replace(ele.oldVal, ele.newVal));

        public static bool IsEmail(this string src)
        {
            var atInd = src.IndexOf("@", StringComparison.OrdinalIgnoreCase);
            return atInd >= 1 && atInd != src.Length - 1;
        }
    }
}
