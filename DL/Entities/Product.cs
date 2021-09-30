using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Product
    {
        public Product()
        {
            LineItems = new HashSet<LineItem>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Genre { get; set; }
        public int? StoreQuantity { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
