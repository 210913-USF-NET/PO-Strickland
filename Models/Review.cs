using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Review
    {

        private int _rating;

        public int Rating {
            get{
                return _rating;

            }
            set{
                if(value > 5 || value < 1)
                    {
                        throw new Exception("rating should be between 1 and 5");
                    }
                else{
                    _rating = value;
                }

            }
        }

        public string Note {get; set;}

        public int Id {get; set;}

        // public List<Product> Product { get; set; }

        public override string ToString(){
            return $"Rating: {this.Rating}, \nNote: {this.Note}";
        }


    }
}