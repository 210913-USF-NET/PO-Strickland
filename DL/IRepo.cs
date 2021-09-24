using System.Collections.Generic;
using Models;
using System;

namespace DL
{
    public interface IRepo
    {
        List<StoreFront> GetAllStoreFronts();

        List<Customer> GetAllCustomers();

        List<Movies> GetAllMovies(); // can take out if necessary 
        Movies AddMovie(Movies newMovie);

        void AddCustomer(Customer cust); // added with the help of nick 

        }
    }
