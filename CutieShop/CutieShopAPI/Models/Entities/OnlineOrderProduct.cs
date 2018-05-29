namespace CutieShop.API.Models.Entities
{
    public partial class OnlineOrderProduct
    {
        public string OnlineOrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }

        public OnlineOrder OnlineOrder { get; set; }
        public Product Product { get; set; }
    }
}
