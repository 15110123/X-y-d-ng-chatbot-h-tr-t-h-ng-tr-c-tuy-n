namespace CutieShop.Models.Entities
{
    public partial class ReportDetails
    {
        public string IdProduct { get; set; }
        public string Unit { get; set; }
        public string IdJoin { get; set; }
        public string ProductName { get; set; }
        public int Id { get; set; }

        public JoinXx JoinXx { get; set; }
    }
}
