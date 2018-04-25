using System;
using System.IO;
using System.Threading.Tasks;
using CutieShop.API.Models.ChatHandlers;
using CutieShop.API.Models.JSONEntities.FacebookRichMessages;
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

                try
                {
                    if (request.result.contexts[0].name == "buystep")
                    {
                        return await new BuyReqHandler(this, request).Result();
                    }
                }
                catch (Exception e)
                {
                    // ReSharper disable once PossibleIntendedRethrow
                    return Json(new { speech = e.Message + e.StackTrace });
                }
                return Json(new
                {
                    speech = "CutieBot chưa hiểu câu hỏi của bạn. Xin hãy đợi nhân viên chúng mình tiếp nhận để trả lời bạn sớm nhất"
                });
            }
            catch (Exception e)
            {
                return Json(new { speech = e.Message + e.StackTrace });
            }
        }
    }
}