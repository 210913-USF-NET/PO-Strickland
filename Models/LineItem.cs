using System;
using System.Collections.Generic;
using Serilog;

namespace Models
{
    public class LineItem{
       //public Product Name { get; set; } // we took the product class and nested it in this Inventory class. 

        public LineItem() {
        }
        
        public int Id {get; set;}
        public int? OrderId {get; set;}

        public int ProductId  {get; set;}

        public int StoreId { get; set; }

        public int? LineItemId {get; set;}

        public Product Item {get; set;}

        public LineItem(string name) : this(){
            this.Name = name;
        }

        public LineItem(string name, int itemquantity) : this(name)
        {
            this.ItemQuantity = itemquantity;
        }

        public Order Order { get; set; }
        public StoreFront Store { get; set; }

        public Product Product { get; set; }
        


        public int? ItemQuantity { get; set; }

        public string Name {get; set;}

        public int InventoryId{get; set;}

        public List<LineItem> LineItems { get; set; } 

        public override string ToString()
        {
            return $"\nMovie: {this.Name} \nAmount: {this.ItemQuantity}";
        }
        

    }
}
