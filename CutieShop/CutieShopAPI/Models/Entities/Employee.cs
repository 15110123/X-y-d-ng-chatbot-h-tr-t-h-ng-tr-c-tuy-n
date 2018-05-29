namespace CutieShop.API.Models.Entities
{
    public partial class Employee
    {
        public string Username { get; set; }
        public string RoleId { get; set; }
        public string Email { get; set; }

        public EmpRole Role { get; set; }
        public Auth UsernameNavigation { get; set; }
    }
}
