using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CutieShop.API.Models.Utils
{
    public static class HttpUtils
    {
        public static async Task<Stream> GetStreamFromUrl(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStreamAsync(url);
            }
        }

        public static async Task<IEnumerable<byte>> GetBytesFromUrl(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetByteArrayAsync(url);
            }
        }
    }
}
