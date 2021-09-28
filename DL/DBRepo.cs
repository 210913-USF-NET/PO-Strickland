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
            Entity.Customer customerToAdd = new Entity.Customer(){
                Name = cust.Name,
                Age = cust.Age,
                Email = cust.Email
                
            }; //when I create a new product, there is no Id. DB will assign it for me

            customerToAdd = _context.Customers.Add(customerToAdd).Entity; //this method tracks what object is being added
            _context.SaveChanges(); //this method will send it to the database. "changes" are not executed util you call the SaveChanges method
            _context.ChangeTracker.Clear();//it tracks entity, so call this. This clears the changeTracker method so it returns to a clean slate. 

            return new Model.Customer(){
                CustomerId = customerToAdd.Id,
                Name = customerToAdd.Name,
                Age = customerToAdd.Age,
                Email = customerToAdd.Email
                
            };
        }

        public Model.LineItem AddLineItem(Model.LineItem line)
        {
            throw new NotImplementedException();
        }

        public Model.Product AddProduct(Model.Product prod)
        {
            Entity.Product productToAdd = new Entity.Product(){
                Name = prod.Name,
                Price = prod.Price,
                Genre = prod.Genre,
                Quantity = prod.Quantity
            }; 

            productToAdd = _context.Products.Add(productToAdd).Entity;
            _context.SaveChanges(); 
            _context.ChangeTracker.Clear(); 

            return new Model.Product(){
                ProductId = productToAdd.Id,
                Name = productToAdd.Name,
                Price = productToAdd.Price,
                Genre = productToAdd.Genre,
                Quantity = productToAdd.Quantity
            };
        }

        public Model.StoreFront AddStoreFront(Model.StoreFront loc)
        {
            Entity.StoreFront storeFrontToAdd = new Entity.StoreFront(){
                Name = loc.Name,
                Address = loc.Address
            }; 

            storeFrontToAdd = _context.StoreFronts.Add(storeFrontToAdd).Entity; 
            _context.SaveChanges(); 
            _context.ChangeTracker.Clear(); 

            return new Model.StoreFront(){
                StoreFrontId = storeFrontToAdd.Id,
                Name = storeFrontToAdd.Name,
                Address = storeFrontToAdd.Address
            };
        }

        public List<Model.Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                Customer => new Model.Customer(){
                    CustomerId = Customer.Id,
                    Name = Customer.Name,
                    Age = Customer.Age,
                    Email = Customer.Email
                    
                }
            ).ToList();
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
            return _context.StoreFronts.Select(
                StoreFront => new Model.StoreFront(){
                    StoreFrontId = StoreFront.Id,
                    Name = StoreFront.Name,
                    Address = StoreFront.Address
                }
            ).ToList();
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