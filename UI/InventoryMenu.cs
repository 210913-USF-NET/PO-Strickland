using System;
using StoreBL;
using System.Collections.Generic;
using Models;

namespace UI
{
    public class Inventory : IMenu
    {
        private IBL _bl;
        public void InventoryMenu(IBL bl){
            this._bl = bl;
        }

        public void Start(){
            //string input = "";
            bool exit = false; 
            do
            {

            Console.WriteLine("\n\nThis is the Inventory List:\n");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("[0] Movies");
            Console.WriteLine("[1] View All Books");
            Console.WriteLine("[2] View All CD's");
            Console.WriteLine("[3] Recommend an Item we should stock");
            Console.WriteLine("[x] Go Back to Main Menu"); 

            switch (Console.ReadLine())
            {
                case "0":
                    // Console.WriteLine("\nAll I have is Lord of the Rings.. Directors Cut");
                    Movies();
                    break;
                case "1":
                    Console.WriteLine("\nI hope you like Harry Potter or Game of Thrones!");
                    break;
                case "2":
                    Console.WriteLine("\nI have Rock from the 70's, 80's, 90's and some alternative");
                    break;
                case "3":
                    Console.WriteLine("\nWhat item do you recommend us stocking?");
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

        private void Movies(){ //similar idea to what was used in RestaurantReviews projects
            List<Movies> allMovies = _bl.GetAllMovies();

            if(allMovies.Count == 0){
                Console.WriteLine("New Orders are on the way");
            }
            else{
            foreach(Movies Movies in allMovies){
                Console.WriteLine(Movies.ToString());
            }
            }

            
        }
        
    }
}