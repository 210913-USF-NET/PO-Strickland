using System.Collections.Generic;
using Models;
using System;

namespace DL
{
    public interface IRepo
    {
        List<StoreFront> GetAllStoreFronts();

        List<Customer> GetAllCustomers();

        // List<Movies> GetAllMovies(); // can take out if necessary 

        List<Product> GetAllProducts();

        // Movies AddMovie(Movies newMovie);

        Customer AddCustomer(Customer cust); // added with the help of nick 

        Product AddProduct(Product prod);
        
        StoreFront AddStoreFront(StoreFront loc);

        }
    }
