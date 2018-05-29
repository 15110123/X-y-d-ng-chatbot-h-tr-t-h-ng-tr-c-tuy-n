using System;
using System.IO;

namespace CutieShop.Models.Utils
{
    public static class FileUtils
    {
        public static Stream AsStream(this byte[] byteArray) => new MemoryStream(byteArray);

        public static byte[] AsByteArray(this Stream stream)
        {
            if (stream is MemoryStream memoryStream)
            {
                return memoryStream.ToArray();
            }
            throw new FormatException();
        }
    }
}
