using System;

namespace Models
{
    public class Inventory //it is a combination of product and quantity and is owned by store class. 
    {
        public Inventory (){} 
        public Inventory(Product name, int quantity, int? productId, int? storeId) 
        {
            this.Name = name;
    this.Quantity = quantity;
    this.ProductId = productId;
    this.StoreId = storeId;
   
        }
                public Product Name { get; set; } // we took the product class and nested it in this Inventory class. 
        
        public int Quantity { get; set; }

        public int Id {get; set;}

        public int? ProductId {get; set;}

        public int? StoreId {get; set;}
        public Product Item {get; set;}
        public Inventory(int? storeId, int? productId, int quantity)
        {
            this.StoreId = storeId;
            this.ProductId = productId;
            this.Quantity = quantity;
        }

        // public static explicit operator object(Inventory v)
        // {
        //     throw new NotImplementedException();
        // }
    }
}