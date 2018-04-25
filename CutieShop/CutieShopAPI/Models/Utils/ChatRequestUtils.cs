namespace CutieShop.API.Models.Utils
{
    public static class ChatRequestUtils
    {
        public static string GetMessengerSenderId(dynamic request) => request.originalRequest.data.sender.id;

        public static string GetMessengerReply(dynamic request) => request.originalRequest.data.message.text;
        public static string GetMessengerResolvedQuery(dynamic request) => request.result.resolvedQuery;
    }
}
