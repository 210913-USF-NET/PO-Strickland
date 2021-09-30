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
        // private readonly Random _random = new Random();  
  
        // // Generates a random number within a range.      
        // public int RandomNumber(int min, int max)  
        // {  
        //     return _random.Next(min, max);  
        // }

        public void Start()
        {   
                // int id = _random.Next(100, 1000000);
                //int totalQuantity;
                Console.WriteLine("Products at Lucky Disks\n");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Price: ");
                string price = Console.ReadLine();
                int parsedPrice;
                bool parseSuccessful = int.TryParse(price, out parsedPrice);
                
                Console.WriteLine("Genre: ");
                string genre = Console.ReadLine();
                
                Console.WriteLine("Quantity: ");
                string quantity = Console.ReadLine();
                int parsedQuantity;
                bool parseSuccess = int.TryParse(quantity, out parsedQuantity);

                
                //Product newProduct = new Product(name, price, genre, totalQuantity);
                Product newProduct = new Product(name, parsedPrice, genre, parsedQuantity); //inheritance
                AddProduct(newProduct); //this add the new product to the AddProduct constructor which takes it to the BL layer
                Console.WriteLine($"\n\nThis product has been updated as: {newProduct.ToString()}");

                // Product addedProduct = _bl.AddProduct(name, price, genre, parsedQuantity); //will transfer info to bl in next layer 
                // Console.WriteLine($"You created {addedProduct}"); 
        }

        private void AddProduct(Product prod){// added with the help of nick

            //_bl.AddProduct(prod); //will transfer info to bl in next layer  

            Product addedProduct = _bl.AddProduct(prod); //will transfer info to bl in next layer 
            Console.WriteLine($"You created {addedProduct}"); 
        }
    }
}