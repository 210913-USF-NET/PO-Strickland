using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class StoreFront
    {
        public int Id { get; set; }
        public string StoreFrontName { get; set; }
        public int? InventoryId { get; set; }
        public string Address { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
