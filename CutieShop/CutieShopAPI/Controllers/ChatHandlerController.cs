using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CutieShop.API.Controllers
{
    [Route("api/[controller]")]
    public class ChatHandlerController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Index(string request = null)
        {
            #region ReadJSON

            //var jsonData = await new StreamReader(Request.Body).ReadToEndAsync();
            //return Json(new {speech = jsonData});

            #endregion

            return Json(new
            {
                speech = "",
                messages = new[]
                {
                new
            {
                type = 2,
                platform = "facebook",
                title = "Bạn muốn mua loại nào ạ?",
                replies = new[] {"Hamster", "Nhím", "Bò sát", "Chó"}
            } }
            });
        }
    }
}