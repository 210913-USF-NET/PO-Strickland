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

        public Customer currCust = Registration.currCust;

        public ShopMenu(IBL bl) //constructor with passing in an instance of business logic to create review menu
        {
            _bl = bl; //instance is saved in private field 
        }
        private StoreFront currStore;
        private List<LineItem> line = new List<LineItem>(); //instead of cart, calling it line
        private Order currentOrder;
        //currentOrder = _bl.CreateCart(currCust.Id, currStore.StoreFrontId);

        public void Start()
        {
            currentOrder  = new Order();
            currStore = SelectStoreFront();
            LineItem newLineItem = new LineItem();
            //List<LineItem> cartList = new List<LineItem> ();
            //currentOrder = _bl.CreateCart(currCust.Id, currStore.StoreFrontId);
            //AddLineItem(newLineItem);
            currStore = _bl.GetStore(currStore.StoreFrontId);
            Console.WriteLine($"Welcome to {currStore.StoreFrontName}");
            List<Inventory> StoreInventory = _bl.ListInventoryByStore(currStore.StoreFrontId);

            if(StoreInventory == null || StoreInventory.Count == 0){

                Console.WriteLine("No Products Currently");
                return;  
            }

            for(int i = 0; i < StoreInventory.Count; i++)
            {
                Console.WriteLine($"[{i}] Item: {StoreInventory[i].Item} Quantity: {StoreInventory[i].Quantity}");
                Product product = _bl.GetAllProducts(StoreInventory[i].ProductId.GetValueOrDefault());
                /*
                this will print out a list of products to review
                */
            }
            
            bool exit = false;
            do
            {
                Console.WriteLine("This is Lucky Disks Menu\n");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] Explore Store");
                Console.WriteLine("[1] Choose StoreFront");
                Console.WriteLine("[2] Place Order");
                Console.WriteLine("[3] See Cart");
                Console.WriteLine("[4] Check Out");
                Console.WriteLine("[x] Go Back To Main Menu");

                switch (Console.ReadLine())
                {
                    case "0":
                        Items();
                    break;
                    case "1":
                        SelectStoreFront();
                        break;
                    case "2":
                        PlaceOrder();
                        break;
                    case "3":
                        Cart(currentOrder.LineItems);
                        break;    
                    case "4":
                        CheckOut(currentOrder, currStore);
                        break;
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
            List<LineItem> cartList = new List<LineItem> ();
            //currentOrder = _bl.CreateCart(currCust.Id, currStore.StoreFrontId);
            string selectedMovie = "";
            string emailNow = "";
            int numberSelected;
            
            Start:
            Console.WriteLine("Please confirm your email by re-entering: ");

            // emailNow = Console.ReadLine(); //potentially take out, do not need

            // Console.WriteLine($"Thank you {emailNow} for your support in our store. Happy shopping!");

            continueShopping: 
            Console.WriteLine("Select a Movie to add to your cart");

            //below is how to pull a list of products already made 

            List<Inventory> StoreInventory = _bl.ListInventoryByStore(currStore.StoreFrontId);

            if(StoreInventory == null || StoreInventory.Count == 0){

                Console.WriteLine("No Products Currently");
                return;  
            }

            for(int i = 0; i < StoreInventory.Count; i++)
            {
                Console.WriteLine($"[{i}] Item: {StoreInventory[i].Item} Quantity: {StoreInventory[i].Quantity}");
                /*
                this will print out a list of products to review
                */
            }
            string input = Console.ReadLine(); //readline brings in string. We want to convert string to int
            int parsedInput;
            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            if(parseSuccess && parsedInput >= 0 && parsedInput < StoreInventory.Count) 
            {
                Inventory selectedProduct = StoreInventory[parsedInput];
                Console.WriteLine($"You selected {selectedProduct.Name}"); 
                selectedMovie = selectedProduct.Item.Name;



                //Order OrderToAdd = new Order(); //empty constructor
                checkout:
                Console.WriteLine("Select an Amount (5 is the max): ");
                int userSelection;
                bool success = int.TryParse(Console.ReadLine(), out userSelection);
                numberSelected = userSelection;


                //numberSelected = userSelection.ToString();

                LineItem newLineItem = new LineItem(selectedMovie, numberSelected); //inheritance 
                newLineItem.ProductId = selectedProduct.Item.ProductId; 
                newLineItem.Item = selectedProduct.Item;
                newLineItem.InventoryId = selectedProduct.Id;
                line.Add(newLineItem);
                //AddLineItem(newLineItem);
                

                // if(!success) {
                //     Console.WriteLine("invalid input");
                //     goto checkout;
                // }
                // try{
                //     //LineItem.ItemQuantity = userSelection; //this could throw an exception
                // }
                // catch(Exception e){
                //     Console.WriteLine(e.Message);
                //     goto checkout; //we caught the exception here
                // }
                // finally{

                // }
            }
            else{
                Console.WriteLine("Invalid Order");
                goto Start;
            }

            string x = "";
            Console.WriteLine("Would you like to continue shopping? Y/N");
            x = Console.ReadLine();

            if (x == "Y"){
                goto continueShopping;
            }
            else{

            // Console.WriteLine($"\nYou purchased:\nMovie:{selectedMovie}\nAmount: {numberSelected}");
            Console.WriteLine("You Purchased: ");

            if(line.Count == 0)
            {
                Console.WriteLine("You made no purchase :/");
            }
            else
            {
                for(int i = 0; i < line.Count; i++) // set i equal to one so it won't read in the null
            {
                Console.WriteLine($"\n[{i}] {line[i].Item} Quantity: {line[i].ItemQuantity} \n______________________________________________");
                
                /*
                this will print out a list of products to review
                */
            }

            currentOrder.CustomersId = currCust.CustomerId; //persisting to the database for orders
            currentOrder.StoreFrontId = currStore.StoreFrontId;
            currentOrder.LineItems = line; 
            
            _bl.PlaceOrder(currentOrder, currStore);


            // cartList.Add(selectItem(selectedMovie, currentOrder.Id));
            // currentOrder.LineItems = cartList;
            }
            }
        }

        private LineItem selectItem(string selectedMovie, int id)
        {
            throw new NotImplementedException();
        }


        //**********************************************************************************************************************************
        private void AddLineItem(LineItem line){// added with the help of nick
            LineItem addedLineItem =_bl.AddLineItem(line); //will transfer info to bl in next layer 
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

        public void Cart(List<LineItem> cart)
        {
            int total = 0;
            foreach (LineItem prod in cart)
            {
                Product product = _bl.GetAllProducts(prod.ProductId);
                Console.WriteLine($"{product.Name} \n Quantity: {prod.ItemQuantity}");
                total += (int)((product.Price) * prod.ItemQuantity);
            }
            System.Console.WriteLine($"Total: ${total}");
        }

        private void CheckOut(Order order, StoreFront store)
        {

            _bl.PlaceOrder(order, store);
            Console.WriteLine(currentOrder);
            // List<Product> allProducts = _bl.GetAllProducts();
            // List<LineItem> allLineItems = _bl.GetAllLineItems();
            // int amt = 0;
            // for(int i = 0; i < allProducts.Count; i++){
            //     for(int j = 0; j < allLineItems.Count; j++){
            //         if ( allProducts[i].Name == allLineItems[j].Name){
            //             amt = (int)allProducts[i].Price;
            //             // amt += amt;
            //             break;
            //         }
            //     }
            // Console.WriteLine($"Your price: {amt}");
            // }

        }

        public StoreFront SelectStoreFront()
        {
            List<StoreFront> allStores = _bl.GetAllStoreFronts();
        pickStore:
            for (int i = 0; i < allStores.Count; i++)
            {
                Console.WriteLine($"[{i}] {allStores[i]}");
            }
            Console.Write("Please choose a location: ");
            string input = Console.ReadLine();
            int parsedInput;

            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            if (parseSuccess && parsedInput >= 0 && parsedInput < allStores.Count)
            {
                StoreFront selectedStore = allStores[parsedInput];
                Log.Information($"Accessing {selectedStore} data");
                return selectedStore;
            }
            else
            {
                Console.WriteLine("Invalid input");
                goto pickStore;
            }
        }


    }
}

    

        

