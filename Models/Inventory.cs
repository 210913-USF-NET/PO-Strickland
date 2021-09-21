namespace Models
{
    public class Inventory //it is a combination of product and quantity and is owned by store class. 
    {
        public Product Item { get; set; } // we took the product class and nested it in this Inventory class. 
        
        public int Quantity { get; set; }


    }
}