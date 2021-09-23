using System.Collections.Generic;
using Models;

namespace StoreBL
{
    public interface IBL
    {
        //List<StoreFront> GetAllStoreFronts();

        List<Movies> GetAllMovies();
        // Movies AddMovie (Movies newMovie);
    }
}