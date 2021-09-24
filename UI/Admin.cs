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
        public void MainMenu(IBL bl){
            this._bl = bl;
        }

        public void Start(){


            //string input = "";
            bool exit = false; 
            do
            {

            Console.WriteLine("\n\nThis is the Inventory List:\n");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("[0] View Customers");
            Console.WriteLine("[1] View Inventory");
            Console.WriteLine("[2] Add Products");
            Console.WriteLine("[3] Add Store Locations");
            Console.WriteLine("[x] Go Back to Main Menu"); 

            switch (Console.ReadLine())
            {
                case "0":
                    Console.WriteLine("Lets see the customers");
                    break;
                case "1":
                    Console.WriteLine("\nHarry Potter or Game of Thrones!");
                    break;
                case "2":
                    new ProductsMenu(new BL(new RAMRepo())).Start();
                    break;
                case "3":
                    Location();
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


        // private void Products(){ //similar idea to what was used in RestaurantReviews projects
            
            
        //     Console.WriteLine("Products at Lucky Disks\n");
        //         Console.WriteLine("Name: ");
        //         string name = Console.ReadLine();
        //         Console.WriteLine("Price: ");
        //         string price = Console.ReadLine();
        //         Console.WriteLine("Genre: ");
        //         string genre = Console.ReadLine();
        //         Console.WriteLine("Quantity: ");
        //         string quantity = Console.ReadLine();

        //         Product newProduct = new Product(name, price, genre, quantity); //inheritance
        //         Console.WriteLine($"\n\nThis product has been updated as: {newProduct.ToString()}");


        // }

        private void Location(){ //similar idea to what was used in RestaurantReviews projects
            
            
            Console.WriteLine("Lucky Disks New Store Locations\n");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Address: ");
                string address = Console.ReadLine();

                StoreFront newStoreFront = new StoreFront(name, address); //inheritance 
                Console.WriteLine($"\n\nLucky Disks has a new location at: {newStoreFront.ToString()}");


    }
}
}