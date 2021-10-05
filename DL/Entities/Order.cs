using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Order
    {
        public Order()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int Id { get; set; }
        public int? CustomersId { get; set; }
        public int? ProductId { get; set; }
        public int? StoreFrontId { get; set; }
        public int? TotalAmount { get; set; }

        public virtual Customer Customers { get; set; }
        public virtual Product Product { get; set; }
        public virtual StoreFront StoreFront { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
