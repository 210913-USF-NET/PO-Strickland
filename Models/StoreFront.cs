using System;
using System.Collections.Generic;

namespace Models
{
    public class StoreFront
    {
        public StoreFront() {
        }

        public StoreFront(string name) : this(){
            this.StoreFrontName = name;
        }

        public StoreFront(string name, string address) : this(name)
        {
            this.Address = address;
        }
        

        public string StoreFrontName { get; set; }
        public string Address { get; set; }

        public int StoreFrontId {get; set;}

        public static int update {get; set;}
        

        public List<Inventory> Inventory { get; set; }

        public override string ToString()
        {
            return $"\nStoreFront: {this.StoreFrontName} \nAddress: {this.Address}";
        }

        public bool Equals(StoreFront loc){
            return this.StoreFrontName == loc.StoreFrontName && this.Address == loc.Address;
        }


    }
}