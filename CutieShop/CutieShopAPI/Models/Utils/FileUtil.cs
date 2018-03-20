using System;
using System.IO;

namespace CutieShop.API.Models.Utils
{
    public static class FileUtil
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
