namespace CutieShop.Models.Entities
{
    public partial class Session
    {
        public string SessionId { get; set; }
        public string Username { get; set; }
        public bool? IsDeleted { get; set; }

        public Auth UsernameNavigation { get; set; }
    }
}
