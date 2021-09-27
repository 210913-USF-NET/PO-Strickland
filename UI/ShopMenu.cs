using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StoreBL;
using Serilog;
using DL;

namespace UI
{
    public class ShopMenu : IMenu
    {
        private IBL _bl;

        public ShopMenu(IBL bl) //constructor with passing in an instance of business logic to create review menu
        {
            _bl = bl; //instance is saved in private field 
        }

        public void Start()
        {
            LineItem newLineItem = new LineItem();
            AddLineItem(newLineItem);

            bool exit = false;
            do
            {
                Console.WriteLine("This is Lucky Disks Menu\n");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] Explore Store");
                Console.WriteLine("[1] Place Order");
                // Console.WriteLine("[2] Check Out");
                Console.WriteLine("[x] Go Back To Main Menu");

                switch (Console.ReadLine())
                {
                    case "0":
                        Items();
                    break;
                    case "1":
                        PlaceOrder();
                        break;
                    // case "2":
                    //     CheckOut();
                    //     break;
                    case "x":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("What are you talking about");
                        break;
                }
            } while(!exit);
        }
        public void PlaceOrder(){
            string selectedMovie = "";
            string emailNow = "";
            string numberSelected = "";
            
            Start:
            Console.WriteLine("Please confirm your email by re-entering: ");

            emailNow = Console.ReadLine();

            Console.WriteLine($"Thank you {emailNow} for your support in our store. Happy shopping!");

            
            Console.WriteLine("Select a Movie to add to your cart");

            //below is how to pull a list of products already made 

            List<Product> allProducts = _bl.GetAllProducts();

            if(allProducts == null || allProducts.Count == 0){

                Console.WriteLine("No Products Currently");
                return;  
            }

            for(int i = 0; i < allProducts.Count; i++)
            {
                Console.WriteLine($"[{i}] {allProducts[i]}");
                /*
                this will print out a list of products to review
                */
            }
            string input = Console.ReadLine(); //readline brings in string. We want to convert string to int
            int parsedInput;
            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            if(parseSuccess && parsedInput >= 0 && parsedInput < allProducts.Count) 
            {
                Product selectedProduct = allProducts[parsedInput];
                Console.WriteLine($"You selected {selectedProduct.Name}"); 
                selectedMovie = selectedProduct.Name;


                Order OrderToAdd = new Order(); //empty constructor
                checkout:
                Console.WriteLine("Select an Amount (5 is the max): ");
                int userSelection;
                bool success = int.TryParse(Console.ReadLine(), out userSelection);
                //numberSelected = userSelection;

                numberSelected = userSelection.ToString();

                LineItem newLineItem = new LineItem(selectedMovie, numberSelected, emailNow); //inheritance 
                AddLineItem(newLineItem);

                if(!success) {
                    Console.WriteLine("invalid input");
                    goto checkout;
                }
                try{
                    OrderToAdd.Quantity = userSelection; //this could throw an exception
                }
                catch(Exception e){
                    Console.WriteLine(e.Message);
                    goto checkout; //we caught the exception here
                }
                finally{
                    //put something here
                    //this get executed if successful or not
                    //use this to clean up resources such as Log.CloseAndFlush();
                }
            }
            else{
                Console.WriteLine("Invalid Order");
                goto Start;
            }
            Console.WriteLine($"\nYou purchased:\nMovie:{selectedMovie}\nAmount: {numberSelected}");
            Console.WriteLine($"Thank you for your purchase and your support!\nA confirmation email will be sent to {emailNow} along with a digit copy. \nPlease choose us again in the future!\n\n");
        }

        private void AddLineItem(LineItem line){// added with the help of nick

            _bl.AddLineItem(line); //will transfer info to bl in next layer 
        }


        private void Items(){ //similar idea to what was used in RestaurantReviews projects
            
            List<Product> allProducts = _bl.GetAllProducts();
            Console.WriteLine("\nHere is a list of our Inventory:");

            if(allProducts.Count == 0)
            {
                Console.WriteLine("New Orders are on the way");
            }
            else
            {
                foreach (Product prod in allProducts)
                {
                    Console.WriteLine("\n " + prod.ToString());
                }

            } 
        }
    }
}
    

        

