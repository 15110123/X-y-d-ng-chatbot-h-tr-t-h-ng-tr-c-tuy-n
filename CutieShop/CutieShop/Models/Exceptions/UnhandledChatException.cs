using System;

// ReSharper disable VirtualMemberCallInConstructor

namespace CutieShop.Models.Exceptions
{
    public class UnhandledChatException : Exception
    {
        public override string Message { get; }

        public UnhandledChatException()
        {
            Message = "Unable to handle the request from chat";
            if (InnerException != null)
                Message += "\n" + InnerException.Message;
        }

        public UnhandledChatException(string additionalMsg)
        {
            Message = "Unable to handle the request from chat";
            Message += "\nAdditional message: " + additionalMsg;
            if (InnerException != null)
                Message += "\n" + InnerException.Message;
        }
    }
}
