using System.Collections.Generic;
namespace Models
{
    public class Order //Customers owns Orders 
    {
        public List<LineItem> LineItems { get; set; }
        public decimal Total { get; set; }

    }
}