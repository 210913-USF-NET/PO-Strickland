using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StoreBL; 

namespace UI
{
    public class ProductsMenu : IMenu
    {
        private IBL _bl; //added with the help of nick 

        public ProductsMenu (IBL bl){

            _bl = bl;

        }

        public void Start()
        {   
                //int totalQuantity;
                Console.WriteLine("Products at Lucky Disks\n");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Price: ");
                string price = Console.ReadLine();
                Console.WriteLine("Genre: ");
                string genre = Console.ReadLine();
                Console.WriteLine("Quantity: ");
                string quantity = Console.ReadLine();
                int parsedQuantity;
                bool parseSuccess = Int32.TryParse(quantity, out parsedQuantity);
                
                //Product newProduct = new Product(name, price, genre, totalQuantity);
                Product newProduct = new Product(name, price, genre, parsedQuantity); //inheritance
                AddProduct(newProduct); //this add the new product to the AddProduct constructor which takes it to the BL layer
                Console.WriteLine($"\n\nThis product has been updated as: {newProduct.ToString()}");
        }

        private void AddProduct(Product prod){// added with the help of nick

            _bl.AddProduct(prod); //will transfer info to bl in next layer 
        }
    }
}