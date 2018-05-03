namespace CutieShop.API.Models.JSONEntities.Settings
{
    public class BuyReq
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string TableRow { get; set; }
    }

    public class MailContent
    {
        public BuyReq BuyReq { get; set; }
    }
}
