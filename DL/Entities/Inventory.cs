using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Inventory
    {
        public Inventory()
        {
            StoreFronts = new HashSet<StoreFront>();
        }

        public int Id { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<StoreFront> StoreFronts { get; set; }
    }
}
