using System;
using System.Collections.Generic;


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
        public Product(string name) : this ()
        {
            this.Name = name;
        }

        //constructor chaining : behaves this way when a age is passed in 
        public Product(string name, string price) : this(name)
        {
            this.Price = price;
        }

        public Product(string name, string price, string genre) : this(name, price)
        {
            this.Genre = genre;
        }

        public Product(string name, string price, string genre, string quantity) : this(name, price, genre)
        {
            this.Quantity = quantity;
        }

        public string Name { get; set; }

        public string Price { get; set; } //decimal is a data type that makes things line up exactly like money

        public string Genre { get; set; }

        public string Quantity { get; set; }

        public List<LineItem> LineItems { get; set; } //products own the lineItem


        public List<Review> Reviews {get; set;} //just added 

        /*
        need this below to attach the review to a product item
        without this, I kept receiving a System.ArgumentOutOfRangeException 
        message. I am not sure why this make it work */ 

        public bool Equals(Product prod){
            return this.Name == prod.Name && this.Price == prod.Price && this.Genre == prod.Genre && this.Quantity == prod.Quantity;
        }

        public override string ToString(){
            return $"Name: {this.Name}, Genre: {this.Genre}, Price: {this.Price}, Quantity: {this.Quantity}";
        }
    }
}