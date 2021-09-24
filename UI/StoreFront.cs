using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StoreBL; 

namespace UI
{
    public class StoreFrontMenu : IMenu
    {
        private IBL _bl; //added with the help of nick 

        public StoreFrontMenu (IBL bl){

            _bl = bl;

        }

        public void Start()
        {
            Console.WriteLine("Lucky Disks New Store Locations\n");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Address: ");
                string address = Console.ReadLine();

                StoreFront newStoreFront = new StoreFront(name, address); //inheritance 
                AddStoreFront(newStoreFront);
                Console.WriteLine($"\n\nLucky Disks has a new location at: {newStoreFront.ToString()}");


    }

        private void AddStoreFront(StoreFront loc){// added with the help of nick

            _bl.AddStoreFront(loc); //will transfer info to bl in next layer 

        }


    }
    

}