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

            // _customer.Add(cust);  //added to memory

            // Console.WriteLine($"Customer: {cust}");
            // List<Customer> allCustomers = GetAllCustomers();

            // allCustomers.Add(cust);

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


            // _product.Add(prod);  //added to memory

            // Console.WriteLine($"Product: {prod}");
            // List<Product> allProducts = GetAllProducts();

            // allProducts.Add(prod);

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

            // _storeFront.Add(loc);  //added to memory

            // Console.WriteLine($"StoreFront: {loc}");
            // List<StoreFront> allStoreFronts = GetAllStoreFronts();

            // allStoreFronts.Add(loc);

            jsonString3 = JsonSerializer.Serialize(allStoreFronts);

            File.WriteAllText(locationFilePath, jsonString3);

            return loc;
        }

        public List<StoreFront> GetAllStoreFronts()
        {
            jsonString3 = File.ReadAllText(locationFilePath);

            return JsonSerializer.Deserialize<List<StoreFront>>(jsonString3);
        }

        // public List<Movies> GetAllMovies{

        // }

        
    }
}