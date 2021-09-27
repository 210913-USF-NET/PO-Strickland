using System.Net.Security;
using System.Collections.Generic;
using Serilog;
using System;

namespace Models
{
    public class Order //Customers owns Orders 
    {
        // public Order(decimal total) : this(){
        //     this.Total = total;
        // }

        // public Order(){
        //     this.LineItem = new List<LineItem>();
        // }
        //public List<LineItem> LineItems { get; set; }

        public string Name {get; set;}

        public string Email{get; set;}

        public List <LineItem> LineItems {get; set;}

        public List <Product> Products {get; set;}
        private int _quantity; 

        public int Quantity {
            get{
                return _quantity;

            }
            set{
                if(value > 5 || value < 1)
                    {
                        throw new Exception("Amount should be between 1 and 5");
                    }
                else{
                    _quantity = value;
                }

            }
        }


        public decimal Total { get; set; }

        // public override string ToString(){
        //     return $"Total Price: {this.Total}\n";
        // }

        // public Order() {
        //      //just added 
        //     this.Product = new List<Product>();
        // }
        public int OrderId {get; set;}
        public int Customerid {get; set;}
    }
}