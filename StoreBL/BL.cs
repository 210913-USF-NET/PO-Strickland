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
        public BL(IRepo repo) //change back to IRepo
        {
            _repo = repo;
        }
        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }

        // public List<Movies> GetAllMovies(){ //delete if necessary
        //     return _repo.GetAllMovies();

        public List<Movies> GetAllMovies(){

            return _repo.GetAllMovies();

        }

        public void AddCustomer(Customer cust){ //added with the help of nick 

            _repo.AddCustomer(cust); // going to DL

        }

        public List<Customer> GetAllCustomers() //Change if doesnt work 
        {
            return _repo.GetAllCustomers();
        }


        
    }
}

