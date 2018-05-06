using System.Collections.Generic;
using CutieShop.API.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static CutieShop.API.Models.Utils.ChatRequestUtils;

namespace CutieShop.API.Models.ChatHandlers
{
    internal abstract class ChatHandler : IChatHandler
    {
        protected SessionStorageHelper Storage;
        protected Controller Receiver;
        protected dynamic Request;

        protected string MsgId => GetMessengerSenderId(Request);
        protected string MsgReply => GetMessengerReply(Request);
        protected string MsgQuery => GetMessengerResolvedQuery(Request);

        protected ChatHandler(Controller receiver, dynamic request)
        {
            Storage = new SessionStorageHelper(this);
            Receiver = receiver;
            Request = request;
        }

        public abstract Task<IActionResult> Result();
    }
}
