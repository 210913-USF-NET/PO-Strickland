using System;
using System.Collections.Generic;


namespace Models
{
    public class Product
    {
        public Product() {} //behaves one way when nothing is passed in 

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

        public override string ToString(){
            return $"Name: {this.Name}, Genre: {this.Genre}, Price: {this.Price}, Quantity: {this.Quantity}";
        }

    }
}