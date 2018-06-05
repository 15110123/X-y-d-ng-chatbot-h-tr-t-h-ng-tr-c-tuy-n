using System.Threading.Tasks;
using CutieShop.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using static CutieShop.Models.Utils.ChatRequestUtils;

namespace CutieShop.Models.ChatHandlers
{
    public abstract class ChatHandler : IChatHandler
    {
        protected SessionStorageHelper Storage;
        //Receiver (receiving controller)
        protected Controller Recv;
        protected dynamic Request;

        protected string MsgId => GetMessengerSenderId(Request);
        protected string MsgReply => GetMessengerReply(Request);
        protected string MsgQuery => GetMessengerResolvedQuery(Request);

        protected ChatHandler(Controller receiver, dynamic request)
        {
            Storage = new SessionStorageHelper(this);
            Recv = receiver;
            Request = request;
        }

        public abstract Task<IActionResult> Result();
    }
}
