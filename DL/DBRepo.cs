using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Models; //this is how you give an alias to a namespace
using Entity = DL.Entities; //this is how you give an alias to a namespace
using Models;
using Microsoft.EntityFrameworkCore;


namespace DL
{
    public class DBRepo : IRepo
    {
        //this needs dbcontext 
        private Entity.P0LuckyDIsksContext _context;


        //and these methods will get data from db
        public DBRepo(Entity.P0LuckyDIsksContext context){
            _context = context; //whatever is passed in, we will save to our private field 
        }
        //and persist to db 
        public Model.Customer AddCustomer(Model.Customer cust) //now we know that we are calling customer models 
        {
            throw new NotImplementedException();
        }

        public Model.LineItem AddLineItem(Model.LineItem line)
        {
            throw new NotImplementedException();
        }

        public Model.Product AddProduct(Model.Product prod)
        {
            throw new NotImplementedException();
        }

        public Model.StoreFront AddStoreFront(Model.StoreFront loc)
        {
            throw new NotImplementedException();
        }

        public List<Model.Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Model.Product> GetAllProducts()
        {
            //select * from in sql query
            return _context.Products.Select(
                Product => new Model.Product(){
                    ProductId = Product.Id,
                    Name = Product.Name,
                    Price = Product.Price,
                    Genre = Product.Genre,
                    Quantity = Product.Quantity
                }
            ).ToList();
        }
            
            
        public List<StoreFront> GetAllStoreFronts()
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product productToUpdate)
        {
            throw new NotImplementedException();
        }

        public Customer loginCustomer(Customer cust)
        {
            throw new NotImplementedException();
        }

        // ToList();
        // }

        // public List<Model.StoreFront> GetAllStoreFronts()
        // {
        //     throw new NotImplementedException();
        // }

        // public Model.Customer loginCustomer(Model.Customer cust)
        // {
        //     throw new NotImplementedException();
        // }

        // public Model.Product UpdateProduct(Model.Product productToUpdate)
        // {
        //     throw new NotImplementedException();
        // }
    }
}