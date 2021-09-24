using System.Collections.Generic;
using Models;

namespace StoreBL
{
    public interface IBL
    {
        List<StoreFront> GetAllStoreFronts();

        List<Movies> GetAllMovies();
        // Movies AddMovie (Movies newMovie);

        List<Customer> GetAllCustomers(); //change if doesnt work 

        void AddCustomer(Customer cust); //added with the help of nick 
    }
}