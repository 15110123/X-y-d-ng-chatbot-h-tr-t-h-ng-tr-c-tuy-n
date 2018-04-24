using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CutieShop.API.Controllers
{
    [Route("api/[controller]")]
    public class ChatHandlerController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            #region ReadJSON

            //var jsonData = await new StreamReader(Request.Body).ReadToEndAsync();
            //return Json(new {speech = jsonData});
            #endregion

            try
            {
                dynamic request = JsonConvert.DeserializeObject(await new StreamReader(Request.Body).ReadToEndAsync());

                if (request.result.contexts[0].name == "buystep")
                {
                    switch ((int)request.result.contexts[0].lifespan)
                    {
                        case 5:
                            {
                                return Json(new
                                {
                                    speech = "",
                                    messages = new[]
                                    {
                                new
                                {
                                    type = 2,
                                    platform = "facebook",
                                    title = "Bạn muốn sản phẩm cho thú cưng nào ạ?",
                                    replies = new[] {"Hamster", "Nhím", "Bò sát", "Chó"}
                                } }
                                });
                            }
                        case 4:
                            {
                                if (request.result.resolvedQuery == "Nhím")
                                {

                                    return Json(new
                                    {
                                        speech = "",
                                        messages = new[]
                                        {
                                        new
                                        {
                                            type = 2,
                                            platform = "facebook",
                                            title = "Bạn muốn mua gì cho bé ạ?",
                                            replies = new[] {"Đồ chơi", "Thức ăn", "Lồng"}
                                        } }
                                    });
                                }

                                return Json(new { });
                            }
                    }
                }

                return Json(new
                {
                    speech = "CutieBot chưa hiểu câu hỏi của bạn. Xin hãy đợi nhân viên chúng mình tiếp nhận để trả lời bạn sớm nhất"
                });
            }
            catch (System.Exception e)
            {
                return Json(new { speech = e.Message + e.StackTrace });
            }
        }
    }
}