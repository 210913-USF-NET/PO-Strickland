using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Genre { get; set; }
        public int? Quantity { get; set; }
    }
}
