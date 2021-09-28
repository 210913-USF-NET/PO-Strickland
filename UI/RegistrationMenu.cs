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
        private IBL _bl; //added with the help of nick 

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
                int parsedAge;
                bool parseSuccess = Int32.TryParse(age, out parsedAge);

                Console.WriteLine("Email Address: ");
                string email = Console.ReadLine();

                Customer newCustomer = new Customer(name, parsedAge, email);
                AddCustomer(newCustomer);
                Console.WriteLine($"\n\nYou are registered as: {newCustomer.ToString()}");
        }

        private void AddCustomer(Customer cust){// added with the help of nick

            Customer addedCustomer = _bl.AddCustomer(cust); //will transfer info to bl in next layer 
            
        }
    }
}