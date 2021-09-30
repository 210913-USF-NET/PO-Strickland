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
            Entity.LineItem LineItemToAdd = new Entity.LineItem(){
                ItemQuantity = line.ItemQuantity
                
            }; 

            LineItemToAdd = _context.LineItems.Add(LineItemToAdd).Entity;
            _context.SaveChanges(); 
            _context.ChangeTracker.Clear(); 

            return new Model.LineItem(){
                LineItemId = LineItemToAdd.Id,
                ItemQuantity = LineItemToAdd.ItemQuantity
            };
        }

        public Model.Product AddProduct(Model.Product prod)
        {
            Entity.Product productToAdd = new Entity.Product(){
                Name = prod.Name,
                Price = prod.Price,
                Genre = prod.Genre,
                StoreQuantity = prod.StoreQuantity
            }; 

            productToAdd = _context.Products.Add(productToAdd).Entity;
            _context.SaveChanges(); 
            _context.ChangeTracker.Clear(); 

            return new Model.Product(){
                ProductId = productToAdd.Id,
                Name = productToAdd.Name,
                Price = productToAdd.Price,
                Genre = productToAdd.Genre,
                StoreQuantity = productToAdd.StoreQuantity
            };
        }

        public Model.StoreFront AddStoreFront(Model.StoreFront loc)
        {
            Entity.StoreFront storeFrontToAdd = new Entity.StoreFront(){
                StoreFrontName = loc.StoreFrontName,
                Address = loc.Address
            }; 

            storeFrontToAdd = _context.StoreFronts.Add(storeFrontToAdd).Entity; 
            _context.SaveChanges(); 
            _context.ChangeTracker.Clear(); 

            return new Model.StoreFront(){
                StoreFrontId = storeFrontToAdd.Id,
                StoreFrontName = storeFrontToAdd.StoreFrontName,
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

        public List<Model.LineItem> GetAllLineItems()
        {
            return _context.LineItems.Select(
                LineItem => new Model.LineItem(){
                    LineItemId = LineItem.Id,
                    ItemQuantity = LineItem.ItemQuantity
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
                    StoreQuantity = Product.StoreQuantity
                }
            ).ToList();
        }
            
        public List<StoreFront> GetAllStoreFronts()
        {
            return _context.StoreFronts.Select(
                StoreFront => new Model.StoreFront(){
                    StoreFrontId = StoreFront.Id,
                    StoreFrontName = StoreFront.StoreFrontName,
                    Address = StoreFront.Address
                }
            ).ToList();
        }
        
        public Product UpdateProduct(Product productToUpdate)
        {
            {
            Entity.Product updatedProduct = (from b in _context.Products
                                        where b.Id == productToUpdate.ProductId
                                        select b).SingleOrDefault();

            updatedProduct.StoreQuantity = productToUpdate.StoreQuantity;

            Product newerProduct = new Models.Product(){
                ProductId = updatedProduct.Id,
                Name = updatedProduct.Name,
                Price = updatedProduct.Price,
                StoreQuantity = updatedProduct.StoreQuantity
                //BreweryId = updatedBrew.BreweryId,
            };

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return newerProduct;
            
        }
        }

        public Customer loginCustomer(Customer cust)
        {
            throw new NotImplementedException();
        }
        public List<Models.Product> ListOfProducts()
        {
            return _context.Products.Select(
                Product => new Model.Product() {
    
                    Name = Product.Name,
                    Price = Product.Price
                    
                }
            ).ToList();

        }


        public Model.LineItem CheckOutList(Models.LineItem line)
        {
            Entity.LineItem toAdd = new Entity.LineItem();
            toAdd.ItemQuantity = line.ItemQuantity;
            toAdd.ProductId = line.ProductId;
            toAdd = _context.LineItems.Add(toAdd).Entity;
            _context.SaveChanges();
            line.Id = toAdd.Id;
            return line;
        }

        // public List<Models.OrderDetails> CustomerOrderHistory()
        // {
        //     return _context.Orderitems.Where(order => order.CustomerId == Models.CurrentContext.CurrentCustomerId).Select(Orderhistory => new Model.OrderDetails(){
        //             Id = Orderhistory.Id,
        //             CustomerId = Orderhistory.CustomerId,
        //             StoreId = Orderhistory.StoresId,
        //             Date = Orderhistory.Date
        //         }
        //     ).ToList();
        // }

        // public List <Models.Order> OrderHistory()
        // {
        //     return _context.Orderitems.Where(order => order.StoresId == Models.CurrentContext.CurrentStoreId).Select(Orderhistory => new Model.OrderDetails(){
        //             Id = Orderhistory.Id,
        //             CustomerId = Orderhistory.CustomerId,
        //             StoreId = Orderhistory.StoresId,
        //             Date = Orderhistory.Date
        //         }
        //     ).ToList();
        // }

        // public List <Models.Customer> ListOfCustomers()
        // {
        //     return _context.Customers.Select(
        //         Cuss => new Model.Customer(){
        //             Name = Custs.Username,
        //             Id = Custs.Id
        //         }
        //     ).ToList();
        // }

        // public Model.OrderDetails CreateNewOrder(Models.OrderDetails order)
        // {
        //     Entity.Orderitem toAdd = new Entity.Orderitem();
        //     toAdd.CustomerId = order.CustomerId;
        //     toAdd.StoresId = order.StoreId;
        //     toAdd.Date = order.Date;
        //     toAdd = _context.Orderitems.Add(toAdd).Entity;
        //     _context.SaveChanges();
        //     order.Id = toAdd.Id;
        //     return order;
        // }

        public List <Models.StoreFront> StoreLocation()
        {
            return _context.StoreFronts.Select(
                StoreFronts => new Model.StoreFront() {
    
                    StoreFrontId = StoreFronts.Id,
                    StoreFrontName = StoreFronts.StoreFrontName,
                    Address = StoreFronts.Address
                }
            ).ToList();

        }

        
        }
    }
