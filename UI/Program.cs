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
            Console.WriteLine("\nWelcome to My Store!");
            StoreFront myStore = new StoreFront(){
                Name = "Lucky Disks",
                Address = "2400 Elders Rd, Charlotte, NC\n"
            };
            Console.WriteLine(myStore.ToString());
            new MainMenu(new BL(new FileRepo())).Start(); //main menu needs a instance of business logic 
        }
    }
}