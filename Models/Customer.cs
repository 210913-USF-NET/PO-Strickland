using System;
using System.Collections.Generic;

namespace Models
{
    public class Customer
    {
        public Customer() {} //behaves one way when nothing is passed in 

        //Constructor overloading (this is an example of polymorphism)
        //The constructor behaves differently
        //depending on what is passed in
        //behaves this way when a name is passed in
        public Customer(string name) : this ()
        {
            this.Name = name;
        }

        //constructor chaining : behaves this way when a age is passed in 
        public Customer(string name, string age) : this(name)
        {
            this.Age = age;
        }

        public Customer(string name, string age, string email) : this(name, age)
        {
            this.Email = email;
        }

        //Property
        public string Name { get; set; }

        public string Age { get; set; }

        public string Email { get; set; }

        public int Id {get; set;}

        public List<Order> Orders { get; set; } //customers owns this order class
        
        //just added
        public override string ToString()
        {
            return $"\nName: {this.Name} \nAge: {this.Age} \nemail: {this.Email}";
        }

        public bool Equals(Customer cust){
            return this.Name == cust.Name && this.Age == cust.Age && this.Email == cust.Email;
        } 

        public int CustomerId {get; set;}
    }
}