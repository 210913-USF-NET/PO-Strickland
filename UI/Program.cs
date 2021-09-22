using System;
using Models;
using StoreBL;
using DL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to Lucky Disks!");
            new MainMenu(new BL(new ExampleRepo())).Start(); //main menu needs a instance of business logic 
            //b
            

        }
    }
}