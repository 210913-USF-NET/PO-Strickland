using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace UI
{
    public class ReviewMenu : IMenu
    {
        // private IBL _bl;

        // public ReviewMenu(IBL bl)
        // {
        //     _bl = bl;
        // }
        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("This is review menu\n");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] Write a review");
                Console.WriteLine("[x] Go Back To Main Menu");

                switch (Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("\nThis portion is still being developed");
                        break;
                    case "x":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("What are you talking about");
                        break;
                }
            } while(!exit);
        }
    }
}