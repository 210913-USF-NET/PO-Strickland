using System;

namespace UI
{
    public class Inventory : IMenu
    {
        public void Start(){
            //string input = "";
            bool exit = false; 
            do
            {

            Console.WriteLine("\n\nThis is the Inventory List:\n");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("[0] View All Movies");
            Console.WriteLine("[1] View All Books");
            Console.WriteLine("[2] View All CD's");
            Console.WriteLine("[x] Go Back to Main Menu"); 

            switch (Console.ReadLine())
            {
                case "0":
                    Console.WriteLine("\nAll I have is Lord of the Rings.. Directors Cut\n");
                    break;
                case "1":
                    Console.WriteLine("\nI hope you like Harry Potter or Game of Thrones!\n");
                    break;
                case "2":
                    Console.WriteLine("\nI have Rock from the 70's, 80's, 90's and some alternative\n");
                    break;
                case "x":
                    Console.WriteLine("\nGoodBye! Make sure to recommend any items we should stock!\n");
                    exit = true;
                    break;
                default :
                    Console.WriteLine("\nWhat are you looking for???\n");
                    break;
            }

        } while (!exit);

        }
        
    }
}