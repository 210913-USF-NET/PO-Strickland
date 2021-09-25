using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StoreBL;
using DL;

namespace UI
{
    public class AdminMenu : IMenu
    {
        private IBL _bl;
        public AdminMenu(IBL bl){
            this._bl = bl;
        }

        public void Start(){


            //string input = "";
            bool exit = false; 
            do
            {

            Console.WriteLine("\nAdmin Menu:\n");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("[0] View Customers");
            Console.WriteLine("[1] View Inventory");
            Console.WriteLine("[2] Add Products");
            Console.WriteLine("[3] Add Store Locations");
            Console.WriteLine("[x] Go Back to Main Menu"); 

            switch (Console.ReadLine())
            {
                case "0":
                    Custs();
                    break;
                case "1":
                    Items();
                    break;
                case "2":
                    new ProductsMenu(new BL(new FileRepo())).Start();
                    break;
                case "3":
                    new StoreFrontMenu(new BL(new FileRepo())).Start();
                    break;
                case "x":
                    Console.WriteLine("\nGoodBye!");
                    exit = true;
                    break;
                default :
                    Console.WriteLine("\nOops you inserted the wrong line");
                    break;
            }

        } while (!exit);

        }

        private void Custs(){ //similar idea to what was used in RestaurantReviews projects
            
            List<Customer> allCustomers = _bl.GetAllCustomers();

            if(allCustomers.Count == 0)
            {
                Console.WriteLine("No one has registered yet :(");
            }
            else
            {
                foreach (Customer cust in allCustomers)
                {
                    Console.WriteLine(cust.ToString());
                }

            }
            

        }

        private void Items(){ //similar idea to what was used in RestaurantReviews projects
            
            List<Product> allProducts = _bl.GetAllProducts();

            if(allProducts.Count == 0)
            {
                Console.WriteLine("New Orders are on the way");
            }
            else
            {
                foreach (Product prod in allProducts)
                {
                    Console.WriteLine(prod.ToString());
                }

            }
            

        }

}
}