using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using System.Text.Json;
using System.IO;

namespace DL
{ 
    // Implement IRepo using singleton design pattern
    // SDP is used if you want one instance of something regardless of where it is 
    //need non access modifer of sealed to make this work
    //sealed means class is no longer inheiritable
    public sealed class RAMRepo : IRepo
    {
        List<StoreFront> _storeFront = new List <StoreFront>();
        List<Product> _product = new List <Product>();
        List<Customer> _customer = new List <Customer>(); //added with the help of nick

    //************************************************************************************************************
        public RAMRepo()
        {
        }

        private static RAMRepo _instance; //only I can access this instance. NO ONE ELSE CAN. We have an instance

        public static RAMRepo GetInstance(){ // a constructor to return the instance 

            if(_instance == null) //if there is nothing, then we will instantiate for it
            {
                _instance = new RAMRepo();
            }
            return _instance; //if not, then return what is there already
        }
    //***********************************************************************************************************
        private static List<Movies> _movies; //where I will store all my movies

        public Movies AddMovie(Movies newMovie){ //we have a way to add a Movie

            _movies.Add(newMovie); //.ADD method comes from system.linq
            return newMovie;

        }
    //***********************************************************************************************************

        // private static List<StoreFront> _storeFronts;
        // private static List<Product> _products; 
        // private static List<Customer> _customers; //made this _customers different than _customer


    //***********************************************************************************************************    
        public List<Movies> GetAllMovies(){ //we have a way to get all the movies

            return _movies;
            
        }
    //***********************************************************************************************************
        
        private const string filePath = "../DL/Customers.json";
        private string jsonString;

        public void AddCustomer(Customer cust)
        {
            _customer.Add(cust);  //added to memory

            Console.WriteLine($"Customer: {cust}");
            List<Customer> allCustomers = GetAllCustomers();

            allCustomers.Add(cust);

            jsonString = JsonSerializer.Serialize(allCustomers);

            File.WriteAllText(filePath, jsonString);
        }

        public List<Customer> GetAllCustomers()
        {
            jsonString = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }
        // public List<StoreFront> GetAllStoreFronts();

        //***********************************************************************************************
        
        private const string productFilePath = "../DL/Products.json";
        private string jsonString2;

        public void AddProduct(Product prod)
        {
            _product.Add(prod);  //added to memory

            Console.WriteLine($"Product: {prod}");
            List<Product> allProducts = GetAllProducts();

            allProducts.Add(prod);

            jsonString2 = JsonSerializer.Serialize(allProducts);

            File.WriteAllText(productFilePath, jsonString2);
        }

        public List<Product> GetAllProducts()
        {
            jsonString2 = File.ReadAllText(productFilePath);

            return JsonSerializer.Deserialize<List<Product>>(jsonString2);
        }
        //***************************************************************************************************
        
        private const string locationFilePath = "../DL/Locations.json";
        private string jsonString3;

        public void AddStoreFront(StoreFront loc)
        {
            _storeFront.Add(loc);  //added to memory

            Console.WriteLine($"StoreFront: {loc}");
            List<StoreFront> allStoreFronts = GetAllStoreFronts();

            allStoreFronts.Add(loc);

            jsonString3 = JsonSerializer.Serialize(allStoreFronts);

            File.WriteAllText(locationFilePath, jsonString3);
        }

        public List<StoreFront> GetAllStoreFronts()
        {
            jsonString3 = File.ReadAllText(locationFilePath);

            return JsonSerializer.Deserialize<List<StoreFront>>(jsonString3);
        }
    //**************************************************************************************************************
    }
}
