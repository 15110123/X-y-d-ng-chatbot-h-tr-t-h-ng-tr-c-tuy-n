using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.Models.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CutieShop.API.Models.ChatHandlers
{
    internal abstract class ChatHandler : IChatHandler
    {
        protected SessionStorageHelper Storage;
        protected Controller Receiver;
        protected dynamic Request;

        protected ChatHandler(Controller receiver, dynamic request)
        {
            Storage = new SessionStorageHelper(this);
            Receiver = receiver;
            Request = request;
        }

        public abstract Task<IActionResult> Result();
    }
}
