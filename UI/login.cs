using DL;
using StoreBL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO; //to use file class
using System;
using System.Collections.Generic;




namespace UI
{
    public class loginMenu : IMenu
    {
        private IBL _bl; //added with the help of nick 

        public loginMenu (IBL bl){

            _bl = bl;
        }

        public void Start()
        {
        string connectionString = File.ReadAllText(@"../connectionString.txt");
        DbContextOptions<P0LuckyDIsksContext> options = new DbContextOptionsBuilder<P0LuckyDIsksContext>()
        .UseSqlServer(connectionString).Options;  
        P0LuckyDIsksContext context = new P0LuckyDIsksContext(options);

            bool correct = false;
            string useremail;
            string response;

            List<Models.Customer> correctEmail = _bl.GetAllCustomers();

            Console.WriteLine("To Sign in, please provide your registered email\n"); //assume an email is unique enough to log into a user account .. I know passwords are important too 
            Console.WriteLine("EMAIL: ");
            useremail = Console.ReadLine();

            for(int i = 0; i < correctEmail.Count; i++){

                if(useremail == correctEmail[i].Email){
                    Console.WriteLine("Welcome back!");
                    new ShopMenu(new BL(new DBRepo(context))).Start();
                    correct = true; // emails match, break out of this loop
                    break;
                }
            }


            if(correct == false){
                Console.WriteLine("incorrect email");
                
                Console.WriteLine("Would you like to register? Select [y] yes or [n] no");
                response = Console.ReadLine(); 

                    if(response == "y"){
                        MenuFactory.GetMenu("register").Start();
                    }
                    else{
                        Console.WriteLine("Please come check out our store in person!\nHave a great day...taking you back to the main menu!");
                    }
            
            }

        }

    }
}
    
