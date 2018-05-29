using System.Collections.Generic;

namespace CutieShop.Models.Entities
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public string InvoiceId { get; set; }
        public int? Sum { get; set; }
        public string BranchAddress { get; set; }
        public string Username { get; set; }

        public User UsernameNavigation { get; set; }
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
