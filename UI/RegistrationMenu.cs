using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StoreBL; 

namespace UI
{
    public class Registration : IMenu
    {
        private IBL _bl;

        public Registration (IBL bl){

            _bl = bl;

        }

        public void Start()
        {   
            

                

                Console.WriteLine("Register at Lucky Disks\n");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Age: ");
                string age = Console.ReadLine();
                Console.WriteLine("Email Address: ");
                string email = Console.ReadLine();

                Customer newCustomer = new Customer(name, age, email);
                AddCustomer(newCustomer);
                Console.WriteLine($"\n\nYou are registered as: {newCustomer.ToString()}");
        }

        private void AddCustomer(Customer cust){

            _bl.AddCustomer(cust); //will transfer info to bl in next layer 

        }


    }

}