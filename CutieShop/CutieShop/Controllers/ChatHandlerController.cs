using System;
using System.IO;
using System.Threading.Tasks;
using CutieShop.Models.ChatHandlers;
using CutieShop.Models.Helpers;
using CutieShop.Models.JSONEntities.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static CutieShop.Models.Utils.ChatRequestUtils;

namespace CutieShop.Controllers
{
    [Route("api/[controller]")]
    public class ChatHandlerController : Controller
    {
        private readonly MailContent _mailContent;

        public ChatHandlerController(IOptions<MailContent> mailContent)
        {
            _mailContent = mailContent.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            #region ReadJSON
            //var jsonData = await new StreamReader(Request.Body).ReadToEndAsync();
            //return Json(new {speech = jsonData});
            #endregion

            try
            {
                var jsonString = await new StreamReader(Request.Body).ReadToEndAsync();
                dynamic request = JsonConvert.DeserializeObject(jsonString);

                try
                {
                    //Check if cancel request
                    if (request.result.metadata.intentName == "shop.test.api.BuyReq.cancel")
                    {
                        SessionStorageHelper.RemoveAllById(GetMessengerSenderId(request));
                        return Json(new{});
                    }

                    //Buy request
                    if (request.result.resolvedQuery == "test api" ||
                        request.result.contexts[0].name == "buystep")
                    {
                        return await new BuyReqHandler(this, request, _mailContent).Result();
                    }
                }
                catch (Exception e)
                {
                    // ReSharper disable once PossibleIntendedRethrow
                    return Json(new { speech = e.Message + e.StackTrace + jsonString });
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