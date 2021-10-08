
using System;
using System.Collections.Generic;
using Serilog;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class StoreFront
    {
        public StoreFront() {
        }

        public StoreFront (int StoreFrontId) : this() { }
        public StoreFront(int StoreFrontId, string name) : this(StoreFrontId){
            this.StoreFrontName = name;
        }

        public StoreFront(int StoreFrontId, string name, string address) : this(StoreFrontId, name)
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
        public LineItem LineItems { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
    }
}