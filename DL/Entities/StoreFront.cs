using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class StoreFront
    {
        public StoreFront()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string StoreFrontName { get; set; }
        public int? InventoryId { get; set; }
        public string Address { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
