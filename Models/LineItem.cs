namespace Models
{
    public class LineItem //pretty much the same as inventory but they belong in Order Class
    {
        public Product Item { get; set; } // we took the product class and nested it in this Inventory class. 
        
        public int Quantity { get; set; }

    }
}