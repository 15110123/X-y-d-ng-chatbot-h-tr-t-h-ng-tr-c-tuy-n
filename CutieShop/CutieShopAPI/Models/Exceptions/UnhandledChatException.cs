using System;

namespace CutieShop.API.Models.Exceptions
{
    public class UnhandledChatException : Exception
    {
        public override string Message { get; }

        public UnhandledChatException()
        {
            Message = "Unable to handle the request from chat";
        }
    }
}
