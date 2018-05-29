namespace CutieShop.Models.Entities
{
    public partial class InvoiceDetails
    {
        public string InvoiceDetailId { get; set; }
        public string ProductName { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? Total { get; set; }
        public string InvoiceId { get; set; }

        public Invoice Invoice { get; set; }
    }
}
