using System;
using System.Collections.Generic;
using Models;
using DL;

namespace StoreBL
{
    //BL is implementing IBL
    public class BL : IBL 
    {
        private IRepo _repo;
        //this is how We receive dependency injection

        public BL(IRepo repo){
            //make sure this IRepo interface has the method GetAllStoreFronts

            _repo = repo; //we assign it ot private IRepo variable
            
        }

        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }
    }
}
