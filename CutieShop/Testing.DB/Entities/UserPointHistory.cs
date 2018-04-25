namespace Testing.DB.Entities
{
    public partial class UserPointHistory
    {
        public string Username { get; set; }
        public int? ChangedValue { get; set; }
        public string OnlineOrderId { get; set; }

        public User UsernameNavigation { get; set; }
    }
}
