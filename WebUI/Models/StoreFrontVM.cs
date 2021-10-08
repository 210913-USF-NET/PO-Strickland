using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebUI.Models
{
    public class StoreFrontsVM
    {
        public StoreFrontsVM(StoreFront loc)
        {
            this.StoreFrontId = loc.StoreFrontId;
            this.StoreFrontName = loc.StoreFrontName;
            this.Address = loc.Address;
        }
        public string Address { get; set; }

        public int StoreFrontId { get; set; }

        public string StoreFrontName { get; set; }


        public StoreFront ToModel()
        {
            return new StoreFront
            {
                StoreFrontId = this.StoreFrontId,
                StoreFrontName = this.StoreFrontName,
                Address = this.Address
            };
        }
    }
}
