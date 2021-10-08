using System;
using System.Collections.Generic;
using Serilog;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class Product
    {
        public Product() {
             //just added 
            this.Reviews = new List<Review>();
        } //behaves one way when nothing is passed in 

        //Constructor overloading (this is an example of polymorphism)
        //The constructor behaves differently
        //depending on what is passed in
        //behaves this way when a name is passed in
        public Product(int ProductId) : this()
        {
            this.ProductId = ProductId;
        }
        public Product(int ProductId, string name) : this(ProductId)
        {
            
            Log.Debug("Creating product");
            this.Name = name;
        }

        //constructor chaining : behaves this way when a age is passed in 
        public Product(int ProductId, string name, int price) : this(ProductId, name)
        {
            this.Price = price;
        }

        public Product(int ProductId, string name, int price, string genre) : this(ProductId, name, price)
        {
            this.Genre = genre;
        }

        // public Product(string name, string price, string genre, int quantity) : this(name, price, genre)
        // {
        //     this.Quantity = quantity;
        // }
        //private string _name;
        
        [Required]
        public string Name { get; set; }
       

        public int Price { get; set; } //decimal is a data type that makes things line up exactly like money

        public string Genre { get; set; }

        //public int? Quantity { get; set; }
        public int StoreQuantity { get; set; }
        

        public int ProductId {get; set;}
       

        public List<LineItem> LineItems { get; set; } //products own the lineItem
        public List<Inventory> Inventory { get; set; }


        public List<Review> Reviews {get; set;} //just added

        public List<Order> Orders {get; set;}

        



        /*
        need this below to attach the review to a product item
        without this, I kept receiving a System.ArgumentOutOfRangeException 
        message. I am not sure why this make it work */

        public bool Equals(Product prod){
            return this.Name == prod.Name && this.Price == prod.Price && this.Genre == prod.Genre;
        } //this compares two products.. it compares if it is the same object in the heap

        // public override string ToString(){
        //     return $"Name: {this.Name}, Genre: {this.Genre}, Price: {this.Price}, Quantity: {this.StoreQuantity}";
        // }

        public override string ToString(){
            return $"Id: {this.ProductId} Name: {this.Name}, Genre: {this.Genre}, Price: {this.Price}";
        }

        public static implicit operator Product(int v)
        {
            throw new NotImplementedException();
        }

        // public static implicit operator object(Product v)
        // {
        //     throw new NotImplementedException();
        // }
    }
}