using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StoreBL;
using DL;
using System.IO;



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

            bool correct = false;
            string useremail;
            string response;

            List<Customer> correctEmail = _bl.GetAllCustomers();

            Console.WriteLine("To Sign in, please provide your registered email\n"); //assume an email is unique enough to log into a user account .. I know passwords are important too 
            Console.WriteLine("EMAIL: ");
            useremail = Console.ReadLine();

            for(int i = 0; i < correctEmail.Count; i++){

                if(useremail == correctEmail[i].Email){
                    Console.WriteLine("Welcome back!");
                    new ShopMenu(new BL(new FileRepo())).Start();
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
    
