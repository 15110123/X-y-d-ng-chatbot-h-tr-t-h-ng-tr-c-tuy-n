using System;
using System.Threading.Tasks;

namespace CutieShop.API.Models.Helpers
{
    public sealed class GuidHelper
    {
        public static async Task<string> CreateGuid()
        {
            var guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
