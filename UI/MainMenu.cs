using DL;
using StoreBL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO; //to use file class
using System;



namespace UI
{
     public class MainMenu : IMenu //we implement IMenu which contains the start method for the user 
    {
        //main menu needs ways to access StoreBL
        // private IBL _bl;
        // public MainMenu(IBL bl)
        // {
        //     _bl = bl;
        // }

        public void Start()
        {
        string connectionString = File.ReadAllText(@"../connectionString.txt");
        DbContextOptions<P0LuckyDIsksContext> options = new DbContextOptionsBuilder<P0LuckyDIsksContext>()
        .UseSqlServer(connectionString).Options;  
        P0LuckyDIsksContext context = new P0LuckyDIsksContext(options);





            bool exit = false; //bool variable to enter and exit the do-while loop 
            string input = ""; //default string variable to take in user input.. type checking
            do
            {
                Console.WriteLine("Here is the main menu:");
                Console.WriteLine("[0] Register as a New User");
                Console.WriteLine("[1] Login");
                Console.WriteLine("[2] Explore Store");
                Console.WriteLine("[3] Leave Reviews");
                Console.WriteLine("[x] Exit");

                input = Console.ReadLine();

                switch (input)
                {
                    case "Admin":
                        //MenuFactory.GetMenu("Admin").Start();
                        new AdminMenu(new BL(new DBRepo(context))).Start();
                        break;

                    case "0":
                        MenuFactory.GetMenu("register").Start();
                        //new Registration(new BL(new FileRepo())).Start(); //implement instance of business logic which is implementing DL: RAMRepo
                        break;

                    case "1":
                        MenuFactory.GetMenu("login").Start();
                        //new Registration(new BL(new FileRepo())).Start(); //implement instance of business logic which is implementing DL: RAMRepo
                        break;    

                    case "2":
                        MenuFactory.GetMenu("inventory").Start();
                        //new InventoryMenu(new BL(new FileRepo())).Start(); //if they select 1, it will go to InventoryMenu file and run that method. 
                        break;

                    case "3":
                        MenuFactory.GetMenu("review").Start();
                        //new ReviewMenu(new BL(new FileRepo())).Start();
                        break;

                    case "x":
                        Console.WriteLine("Have a Great Day!");
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