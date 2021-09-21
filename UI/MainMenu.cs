using System;
using StoreBL;

namespace UI
{
     public class MainMenu : IMenu //we implement IMenu which contains the start method for the user 
    {
        //main menu needs ways to access BL
        private IBL _bl;
        public MainMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            bool exit = false; //bool variable to enter and exit the do-while loop 
            string input = ""; //default string variable to take in user input   
            do
            {
                Console.WriteLine("Here is the main menu:");
                Console.WriteLine("[0] Explore Store");
                Console.WriteLine("[1] Leave Reviews");
                Console.WriteLine("[x] Exit");

                input = Console.ReadLine();

                switch (input)
                {

                    case "0":
                        Console.WriteLine("You want to explore the store"); 
                        break;

                    case "1":
                        Console.WriteLine("You want to leave a review");
                        break;

                    case "x":
                        Console.WriteLine("Adios");
                        exit = true; // when i know they want to leave. Flip exit to true. 
                        break;

                    default: //triggered when none of this matches
                        Console.WriteLine("What are you doing???");
                        break;
                }
            
            }while (!exit); //when true, it will exit. 

        }

    }
}