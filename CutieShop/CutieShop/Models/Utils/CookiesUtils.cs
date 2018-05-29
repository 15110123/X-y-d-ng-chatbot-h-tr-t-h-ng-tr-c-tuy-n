using Microsoft.AspNetCore.Mvc;

namespace CutieShop.Models.Utils
{
    public static class CookiesUtils
    {
        public static string SessionId(this Controller controller)
        {
            return controller.Request.Cookies["sessionId"];
        }
    }
}