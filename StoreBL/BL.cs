using System;
using System.Collections.Generic;
using DL;
using Models;

namespace StoreBL
{
    public class BL : IBL
    {
        private IRepo _repo;

        //dependency injection
        public BL(IRepo repo) 
        {
            _repo = repo;
        }

        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }

        public List<Movies> GetAllMovies()
        {

            return _repo.GetAllMovies();

        }

        public void AddCustomer(Customer cust)
        { //added with the help of nick 

            _repo.AddCustomer(cust); // going to DL
        }

        public List<Customer> GetAllCustomers() //Change if doesnt work 
        {
            return _repo.GetAllCustomers();
        }


        public void AddProduct(Product prod)
        { //added with the help of nick 

            _repo.AddProduct(prod); // going to DL
        }

        public List<Product> GetAllProducts() //Change if doesnt work 
        {
            return _repo.GetAllProducts();
        }

    }
}

