using System;
using DL;
using StoreBL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO; //to use file class


namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuString)
        {
                string connectionString = File.ReadAllText(@"../connectionString.txt");

                DbContextOptions<P0LuckyDIsksContext> options = new DbContextOptionsBuilder<P0LuckyDIsksContext>() //to get the options, we use options builder
                //it needs 'options' mostly bc it needs a connection stream

                .UseSqlServer(connectionString).Options; //we let options builder know that we are using SQL server. Also, provide where to get that database from 
                //also give options property to get the option itself. This is all done through EF core options and options builder
                
                P0LuckyDIsksContext context = new P0LuckyDIsksContext(options); //pass in options here so context knows where to go and what to expect
                //now that everything is being uploaded to the database, my fileRepo is irrelevant now 

            switch (menuString.ToLower())
            {

                case "main":
                    return new MainMenu(new BL(new DBRepo(context)));//new BL(new FileRepo()));
                //case "Admin":
                    //return new AdminMenu(new BL(new FileRepo())); //no break statements because we are returning out of all of these options
                // case "Admin":
                //     return new AdminMenu(new BL(new DBRepo(context)));
                case "register":
                    return new Registration(new BL(new DBRepo(context))); //tells the repo here is the database, go query from here 
                case "login":
                    return new loginMenu(new BL(new DBRepo(context)));
                case "inventory":
                    return new InventoryMenu(new BL(new DBRepo(context)));
                // case "review":
                //     return new ReviewMenu(new BL(new DBRepo(context)));
                default:
                    return null;
            }
        }
    }
}
    

