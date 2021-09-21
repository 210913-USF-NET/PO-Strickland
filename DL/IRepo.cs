using System.Collections.Generic;
using Models;

namespace DL
{
    //this is promised to business logic (BL)
    public interface IRepo
    {
        List<StoreFront> GetAllStoreFronts();
        
    }
}