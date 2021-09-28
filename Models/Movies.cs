using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Movies
    {
        public string Title {get; set;}
        public string Quantity {get; set;}
        public decimal Price {get; set;}

        public override string ToString(){
            return $"Title: {this.Title}, Quantity: {this.Quantity}, Price: {this.Price}";
        }
    }
}