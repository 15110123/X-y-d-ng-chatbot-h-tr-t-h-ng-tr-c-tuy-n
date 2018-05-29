namespace CutieShop.Models.Entities
{
    public partial class UserPoint
    {
        public string Username { get; set; }
        public int? Value { get; set; }

        public User UsernameNavigation { get; set; }
    }
}
