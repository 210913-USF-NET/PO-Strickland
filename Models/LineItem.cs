using System;
using System.Collections.Generic;
using Serilog;

namespace Models
{
    public class LineItem{
       //public Product Name { get; set; } // we took the product class and nested it in this Inventory class. 

        public LineItem() {
        }
        

        public int OrderId {get; set;}

        public int ProductId  {get; set;}

        public LineItem(string name) : this(){
            this.Name = name;
        }

        public LineItem(string name, string quantity) : this(name)
        {
            this.Quantity = quantity;
        }

        public LineItem(string name, string quantity, string email) : this(name, quantity)
        {
            this.Email = email;
        }


        public string Quantity { get; set; }

        public string Name {get; set;}

        public string Email{get; set;}

        public List<LineItem> LineItems { get; set; } 

        public override string ToString()
        {
            return $"\nMovie: {this.Name} \nAmount: {this.Quantity} \nEmail Confirmation: {this.Email}";
        }
        

    }
}
