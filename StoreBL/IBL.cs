using System.Collections.Generic;
using Models;

namespace StoreBL
{
    public interface IBL
    {
        //lets display all stores
        List<StoreFront> GetAllStoreFronts();
    }
}