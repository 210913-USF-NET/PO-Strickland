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
            Console.WriteLine("Welcome to My Store!");
            new MainMenu(new BL(new ExampleRepo())).Start(); //main menu needs a instance of business logic 
            //business logic needs something of an instance that implements IRepo
        }
    }
}