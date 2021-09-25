using System;
using StoreBL;
using System.Collections.Generic;
using Models;

namespace UI
{
    public class InventoryMenu : IMenu 
    {
        private IBL _bl;
        /*
        if pubic class name (InventoryMenu)(above) and public name for bl (below)
        (InventoryMenu) are the same. Then you do not need void in front 
        of public below. BUT, go to where it is being called and insert
        new InventoryMenu(new BL(new FileRepo())).Start();
        */
        public InventoryMenu(IBL bl){ 
            this._bl = bl;
        }

        public void Start(){
            //string input = "";
            bool exit = false; 
            do
            {

            Console.WriteLine("\n\nThis is the Inventory List:\n");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("[0] View All Products");
            Console.WriteLine("[1] See other store locations");
            Console.WriteLine("[2] Recommend an Item we should stock");
            Console.WriteLine("[x] Go Back to Main Menu"); 

            switch (Console.ReadLine())
            {
                case "0":
                    // Console.WriteLine("\nAll I have is Lord of the Rings.. Directors Cut");
                    Items();
                    break;
                case "1":
                    Locations();
                    break;
                case "2":
                    Console.WriteLine("What movie do you recommend?");
                    break;
                case "x":
                    Console.WriteLine("\nGoodBye!");
                    exit = true;
                    break;
                default :
                    Console.WriteLine("\nWhat are you looking for??? Try again");
                    break;
            }

        } while (!exit);

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
        private void Locations(){ //similar idea to what was used in RestaurantReviews projects
            
            List<StoreFront> allStoreFronts = _bl.GetAllStoreFronts();

            if(allStoreFronts.Count == 0)
            {            }
            else
            {
                foreach (StoreFront loc in allStoreFronts)
                {
                    Console.WriteLine(loc.ToString());
                }
            }
        }
    }
}