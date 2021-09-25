using System.Collections.Generic;
using Models;

namespace StoreBL
{
    public interface IBL
    {
    //******************************************************************
        List<StoreFront> GetAllStoreFronts();

        void AddStoreFront(StoreFront loc);
    //******************************************************************
        // List<Movies> GetAllMovies();

        // Movies AddMovie (Movies newMovie);
    
    //******************************************************************
        List<Customer> GetAllCustomers(); //change if doesnt work 

        void AddCustomer(Customer cust); //added with the help of nick 

    //*******************************************************************
        List<Product> GetAllProducts();

        void AddProduct(Product prod);
    //********************************************************************
    }

    /*
    when we have an interface (same is true for interface in Models, UI, DL)
    these members are public by default. This way we don't have to have 
    access modifier in front of it
    */
}