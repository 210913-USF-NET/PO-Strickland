using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class PlacedOrder
    {
        public PlacedOrder(){}
        
        public int Id {get; set;}
        public int? CustomerId {get; set;}

        public int? StoreFrontId {get; set;}

        public override string ToString()
        {
            return $"StoreId: {StoreFrontId}, OrderId: {Id} , CustomerId: {CustomerId}";
        }
    }
}