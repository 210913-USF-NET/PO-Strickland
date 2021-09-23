using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IRepo
    {
        List<StoreFront> GetAllStoreFronts();

        List<Movies> GetAllMovies(); // can take out if necessary 
        // Movies AddMovie(Movies newMovie);

        void AddCustomer(Customer cust);

        }
    }
