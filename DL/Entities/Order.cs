using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Order
    {
        public int Id { get; set; }
        public int CustomersId { get; set; }
        public int ProductId { get; set; }
        public int? TotalAmount { get; set; }

        public virtual Customer Customers { get; set; }
        public virtual Product Product { get; set; }
    }
}
