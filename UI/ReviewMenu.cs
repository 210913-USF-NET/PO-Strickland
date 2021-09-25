using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StoreBL;
using Serilog;

namespace UI
{
    public class ReviewMenu : IMenu
    {
        private IBL _bl;

        public ReviewMenu(IBL bl) //constructor with passing in an instance of business logic to create review menu
        {
            _bl = bl; //instance is saved in private field 
        }

        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("This is Review Menu\n");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] Write a Review");
                Console.WriteLine("[1] View Reviews");
                Console.WriteLine("[x] Go Back To Main Menu");

                switch (Console.ReadLine())
                {
                    case "0":
                        WriteAReview();
                        break;
                    case "1":
                        Console.WriteLine("put something here");
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
        /*
        this review will be chained to the restauant model.
        it will be stored there.
        */
        private void WriteAReview(){

            reviewStart:
            
            Console.WriteLine("Select a product to write a review for");

            //below is how to pull a list of products already made 

            List<Product> allProducts = _bl.GetAllProducts();

            if(allProducts == null || allProducts.Count == 0){

                Console.WriteLine("No Products Currently");
                return; // this will finish the function right here. Nothing else matters below if we dont have a product to review. 
            }

            /*now we will loop through all products and print it to viewer
            we will use for loop instead of foreach so we have 
            access to indexes we want of allProduct list
            This way, we can do string interpolation on line 67*/
            for(int i = 0; i < allProducts.Count; i++)
            {
                Console.WriteLine($"[{i}] {allProducts[i]}");
                /*
                this will print out a list of products to review
                */
            }
            string input = Console.ReadLine(); //readline brings in string. We want to convert string to int
            int parsedInput;
            bool parseSuccess = Int32.TryParse(input, out parsedInput); //tryParse convert to int and returns a boolean. It logs the result here
            //out is a keyword that will pass the variable if it passes this parsed bool test
            
            if(parseSuccess && parsedInput >= 0 && parsedInput < allProducts.Count) //this is cool boundary created on user selection input
            {
                Product selectedProduct = allProducts[parsedInput];
                Console.WriteLine($"You selected {selectedProduct.Name}"); //.Name will only return the name. Not the price, genre, or quantity. 


                Review reviewToAdd = new Review(); //empty constructor
                rating:
                Console.WriteLine("Rating (1-5): ");
                int userRating;
                bool success = int.TryParse(Console.ReadLine(), out userRating);
                if(!success) {
                    Console.WriteLine("invalid input");
                    goto rating;
                }
                try{
                    reviewToAdd.Rating = userRating; //this could throw an exception
                }
                catch(Exception e){
                    Console.WriteLine(e.Message);
                    goto rating; //we caught the exception here
                }
                finally{
                    //put something here
                    //this get executed if successful or not
                    //use this to clean up resources such as Log.CloseAndFlush();
                }

                Console.WriteLine("Note about product: ");
                reviewToAdd.Note = Console.ReadLine();
                selectedProduct.Reviews.Add(reviewToAdd); //this part was added right after adding 'public bool Equals(Product prod){' in models class 

                Product updatedProduct = _bl.UpdateProduct(selectedProduct);
                Console.WriteLine("Review has been added!");
                Console.WriteLine(updatedProduct);
                foreach(Review review in updatedProduct.Reviews){
                    Log.Debug("Adding review to product.. ");
                    Console.WriteLine(review); //loop through the reviews list and update the product 
                }
            }
            else{
                Console.WriteLine("invalid input");
                goto reviewStart; //reviewStart is top of this block. The goto keyword creates a region here.
                //region is a way to mark a place in code, and if activated, you can jump to that place
                //you can use goto keyword in a switch statement
            }
        }
    }
}