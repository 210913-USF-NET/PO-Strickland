using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StoreBL;
using DL;
using Microsoft.EntityFrameworkCore;
using DL.Entities;
using System.IO;


namespace UI
{
    public class AdminMenu : IMenu
    {
        
        private IBL _bl;
        public AdminMenu(IBL bl){
            this._bl = bl;
        }

        public void Start(){

        string connectionString = File.ReadAllText(@"../connectionString.txt");
        DbContextOptions<P0LuckyDIsksContext> options = new DbContextOptionsBuilder<P0LuckyDIsksContext>()
        .UseSqlServer(connectionString).Options;  
        P0LuckyDIsksContext context = new P0LuckyDIsksContext(options);


            //string input = "";
            bool exit = false; 
            do
            {

            Console.WriteLine("\nAdmin Menu:\n");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("[0] View Customers");
            Console.WriteLine("[1] View Inventory");
            Console.WriteLine("[2] Add Products");
            Console.WriteLine("[3] Change Products");
            Console.WriteLine("[4] Add Store Locations");
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
                    new ProductsMenu(new BL(new DBRepo(context))).Start();
                    break;
                case "3":
                    Change();
                    break;
                case "4":
                    new StoreFrontMenu(new BL(new DBRepo(context))).Start();
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
            
            List<Models.Customer> allCustomers = _bl.GetAllCustomers();

            if(allCustomers.Count == 0)
            {
                Console.WriteLine("No one has registered yet :(");
            }
            else
            {
                foreach (Models.Customer cust in allCustomers)
                {
                    Console.WriteLine(cust.ToString());
                }
            }
        }

        private void Items(){ //similar idea to what was used in RestaurantReviews projects
            
            List<Models.Product> allProducts = _bl.GetAllProducts();

            if(allProducts.Count == 0)
            {
                Console.WriteLine("New Orders are on the way");
            }
            else
            {
                foreach (Models.Product prod in allProducts)
                {
                    Console.WriteLine(prod.ToString());
                }

            }
            

        }

        public Models.Product Change(){

            Console.WriteLine("Choose a Movie to change:");

            List<Models.Product> Products = _bl.GetAllProducts();
            for(int i = 0; i < Products.Count; i++){
                Console.WriteLine($"[{i}] {Products[i]}");
            }
            int selectId = Int32.Parse(Console.ReadLine());
            Models.Product productToChange = Products[selectId];

            Change:
            Console.WriteLine($"How many {productToChange} would you like to add? or take away? ");
            try{
                productToChange.Quantity += Int32.Parse(Console.ReadLine());
            }
            catch(System.FormatException){
                Console.WriteLine("Please use a number");
                goto Change;
            }

            Models.Product changedMovie = _bl.UpdateProduct(productToChange);

            return changedMovie;

        }

}
}