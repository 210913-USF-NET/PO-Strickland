using System;
using System.Collections.Generic;
using DL;
using Models;

namespace StoreBL //never have the namespace title the same as the public class title. This will cause an error. 
//also name title is StoreBL. We use this when connecting to other projects with 'using' keyword
//thus, 'using StoreBL;' in other parts of the program. 
{
    public class BL : IBL
    {
        private IRepo _repo;

        //dependency injection
        public BL(IRepo repo) 
        {
            _repo = repo;
        }
        //*********************************************************
        public void AddStoreFront(StoreFront loc)
        {
            _repo.AddStoreFront(loc);

        }
        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }
        //*********************************************************

        //**********************************************************

        public void AddCustomer(Customer cust)
        { //added with the help of nick 

            _repo.AddCustomer(cust); // going to DL
        }

        public List<Customer> GetAllCustomers() //Change if doesnt work 
        {
            return _repo.GetAllCustomers();
        }
        //***********************************************************

        public void AddProduct(Product prod)
        { //added with the help of nick 

            _repo.AddProduct(prod); // going to DL
        }

        public List<Product> GetAllProducts() //Change if doesnt work 
        {
            return _repo.GetAllProducts();
        }
        //*************************************************************

        public Product UpdateProduct(Product productToUpdate )

        {
            return _repo.UpdateProduct(productToUpdate);
        }
    }

    /*
    when we actually implement the interface, we have to declare the
    access modifer, we have to have these as public. 
    */



}

