using static System.Console;
using System.Threading.Tasks;
using CutieShop.Models.JSONEntities.Settings;
using Microsoft.AspNetCore.Mvc;

namespace CutieShop.Models.ChatHandlers
{
    internal sealed class BuyReqHandlerProxy : ChatHandler
    {
        private readonly BuyReqHandler _buyReqHandler;

        public BuyReqHandlerProxy(Controller receiver, dynamic request, MailContent mailContent)
            : base(receiver, (object)request)
        {
            WriteLine("Building handler from proxy");
            _buyReqHandler = new BuyReqHandler(receiver, request, mailContent);
            WriteLine("Done!");
        }

        public override async Task<IActionResult> Result()
        {
            WriteLine("Getting result");
            var res = await _buyReqHandler.Result();
            WriteLine("Done!");
            return res;
        }
    }
}
