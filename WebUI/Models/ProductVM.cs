using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebUI.Models
{
    public class ProductVM
    {
        public ProductVM() { }

        public ProductVM(Product prod)
        {
            this.ProductId = prod.ProductId;
            this.Name = prod.Name;
            this.Genre = prod.Genre;
            this.Price = prod.Price;
            this.StoreQuantity = prod.StoreQuantity;
        }

        [Required]
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }

        //public int? Quantity { get; set; }
        public int StoreQuantity { get; set; }


        public int ProductId { get; set; }

        public Product ToModel()
        {
            return new Product
            {
                ProductId = this.ProductId,
                Name = this.Name,
                Genre = this.Genre,
                Price = this.Price,
                StoreQuantity = this.StoreQuantity
            };
        }
    }
}

   
