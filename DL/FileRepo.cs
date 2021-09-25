using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using System.Text.Json;
using System.IO;

namespace DL
{
    public class FileRepo : IRepo
    {
        // private static List<Customer> _customer;
        // private static List<StoreFront> _storeFront;
        // private static List<Product> _product;

        private const string filePath = "../DL/Customers.json";
        private string jsonString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cust"></param>
        /// <returns> the added cust </returns>

        public Customer AddCustomer(Customer cust)
        {
            List<Customer> allCustomers = GetAllCustomers();
            allCustomers.Add(cust);

            jsonString = JsonSerializer.Serialize(allCustomers);

            File.WriteAllText(filePath, jsonString);

            return cust;
        }

        public List<Customer> GetAllCustomers()
        {
            jsonString = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }

        //**********************************************************************
        private const string productFilePath = "../DL/Products.json";
        private string jsonString2;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prod"></param>
        /// <returns> the added prod </returns> //added this line in 

        public Product AddProduct(Product prod)
        {
            List<Product> allProducts = GetAllProducts();
            allProducts.Add(prod);

            jsonString2 = JsonSerializer.Serialize(allProducts);

            File.WriteAllText(productFilePath, jsonString2);

            return prod;
        }

        public List<Product> GetAllProducts()
        {
            jsonString2 = File.ReadAllText(productFilePath);

            return JsonSerializer.Deserialize<List<Product>>(jsonString2);
        }

        //***********************************************************************

        private const string locationFilePath = "../DL/Locations.json";
        private string jsonString3;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loc"></param>
        /// <returns> the added loc </returns>

        public StoreFront AddStoreFront(StoreFront loc)
        {
            List<StoreFront> allStoreFronts = GetAllStoreFronts();
            allStoreFronts.Add(loc);

            jsonString3 = JsonSerializer.Serialize(allStoreFronts);

            File.WriteAllText(locationFilePath, jsonString3);

            return loc;
        }

        public List<StoreFront> GetAllStoreFronts()
        {
            jsonString3 = File.ReadAllText(locationFilePath);

            return JsonSerializer.Deserialize<List<StoreFront>>(jsonString3);
        }
    //**************************************************************************

        private const string ReviewsfilePath = "../DL/Reviews.json";
        private string jsonString4;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rev"></param>
        /// <returns>the added rev</returns>


        public Review AddReview(Review rev)
        {
            List<Review> allReviews = GetAllReviews();
            allReviews.Add(rev);

            jsonString4 = JsonSerializer.Serialize(allReviews);

            File.WriteAllText(ReviewsfilePath, jsonString4);

            return rev;
        }

        public List<Review> GetAllReviews()
        {
            jsonString4 = File.ReadAllText(ReviewsfilePath);

            return JsonSerializer.Deserialize<List<Review>>(jsonString4);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="productToUpdate"></param>
        /// <returns></returns>
        public Product UpdateProduct(Product productToUpdate)
        {
            //first, find the restaurant to update
            //by first, getting all restaurants, using getAllRestaurants method
            //and then use FindIndex method with the lambda expression
            //to get me the location of the restaurant in the list
            //if there is a match
            List<Product> allProducts = GetAllProducts();
            int ProductIndex = allProducts.FindIndex(r => r.Equals(productToUpdate));

            //update the restaurant in the list itself
            allProducts[ProductIndex] = productToUpdate;

            //serialize 
            jsonString2 = JsonSerializer.Serialize(allProducts);

            //write to a file
            File.WriteAllText(productFilePath, jsonString2);
            
            return productToUpdate;
        }

        
    }
}