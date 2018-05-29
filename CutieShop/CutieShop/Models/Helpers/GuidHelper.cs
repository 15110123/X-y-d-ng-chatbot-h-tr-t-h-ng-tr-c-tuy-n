using System;

namespace CutieShop.Models.Helpers
{
    public sealed class GuidHelper
    {
        public string CreateGuid()
        {
            var guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
