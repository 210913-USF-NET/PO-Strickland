using System;
using System.Collections.Generic;

namespace Models
{
    public class StoreFront
    {
        public StoreFront() {
        }

        public StoreFront(string name) : this(){
            this.Name = name;
        }

        public StoreFront(string name, string address) : this(name)
        {
            this.Address = address;
        }
        

        public string Name { get; set; }
        public string Address { get; set; }

        public int StoreFrontId {get; set;}
        

        public List<Inventory> Inventories { get; set; }

        public override string ToString()
        {
            return $"\nStoreFront: {this.Name} \nAddress: {this.Address}";
        }

        public bool Equals(StoreFront loc){
            return this.Name == loc.Name && this.Address == loc.Address;
        }


    }
}