using System.Net.Security;
using System.Collections.Generic;
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
        public List<LineItem> LineItems { get; set; }
        public decimal Total { get; set; }

        // public override string ToString(){
        //     return $"Total Price: {this.Total}\n";
        // }

    }
}