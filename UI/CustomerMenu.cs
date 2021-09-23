using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace UI
{
    public class Registration : IMenu
    {
        public void Start()
        {
            // private static void CreateCustomer(){

                Console.WriteLine("Register at Lucky Disks\n");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Age: ");
                string age = Console.ReadLine();
                Console.WriteLine("Email Address: ");
                string email = Console.ReadLine();

                Customer newCustomer = new Customer(name, age, email);
                Console.WriteLine($"\n\nYou are registered as: {newCustomer.ToString()}");
        }
    }
}