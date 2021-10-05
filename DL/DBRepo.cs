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
                Genre = prod.Genre
            }; 

            productToAdd = _context.Products.Add(productToAdd).Entity;
            _context.SaveChanges(); 
            _context.ChangeTracker.Clear(); 

            return new Model.Product(){
                ProductId = productToAdd.Id,
                Name = productToAdd.Name,
                Price = productToAdd.Price,
                Genre = productToAdd.Genre
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

        public List<Model.Inventory> GetAllInventory()
        {
            return _context.Inventories.Select(
                Inventory => new Model.Inventory(){
                    Id = Inventory.Id,
                    StoreId = Inventory.StoreId,
                    ProductId = Inventory.ProductId,
                    Quantity = (int)Inventory.Quantity
                    
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
                    Genre = Product.Genre
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
        
        // public int Inventory UpdatedInventory(Models.StoreFront StoreFront, Models.LineItem Product)
        // {
        //     Models.Inventory test = StoreFront.Inventory.FirstOrDefault(i => i.ProductId == Product.ProductId && StoreFront.StoreFrontId == i.StoreId);
        //     Entity.Inventory updatedInventory = new Entity.Inventory()
        //     {
        //         Id = test.Id,
        //         StoreId =  StoreFront.StoreFrontId,
        //         Quantity = (int)(test.Quantity - Product.ItemQuantity)
                
        //     };

        //     updatedInventory = _context.Inventories.Update(updatedInventory).Entity;
        //     _context.SaveChanges();
        //     _context.ChangeTracker.Clear();
        //     int newAmount = Convert.ToInt32(updatedInventory.Quantity);

        //     return newAmount;
        // }  

        public Models.Order CreateCart(int CustomersId, int StoreId)
        {
            // Entity.Order cart = new Entity.Order() { };
            // cart.CustomerId = CustomerId;
            Entity.Order cart = new Entity.Order()
            {
                CustomersId = CustomersId,
                StoreFrontId = StoreId,
            };
            cart = _context.Add(cart).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Models.Order()
            {
                Id = cart.Id,
                CustomersId = (int)cart.CustomersId,
                StoreFrontId = (int)cart.StoreFrontId
            };
        }
        //Select * FROM Inventory JOIN PRODUCT ON Product.Id = Inventory.ProductId
        public List<Models.Inventory> ListInventoryByStore(int StoreFrontId)
        {
            return _context.Inventories.Include("Product").Where(i => i.StoreId == StoreFrontId ).Select(
                Inventory => new Model.Inventory(){
                    Id = Inventory.Id,
                    StoreId = Inventory.StoreId,
                    ProductId = Inventory.ProductId,
                    Quantity = (int)Inventory.Quantity,
                    Item = new Models.Product (){
                        ProductId = Inventory.Product.Id,
                        Name = Inventory.Product.Name,
                        Genre = Inventory.Product.Genre,
                        Price = Inventory.Product.Price,
                        StoreQuantity = Inventory.Product.Quantity
                    }
                }
            ).ToList();
        }
        public Models.Order PlaceOrder(Models.Order order, Models.StoreFront store)
        {
            Entity.Order ordertoAdd = new Entity.Order(){
                StoreFrontId = order.StoreFrontId,
                CustomersId = order.CustomersId
            };
            ordertoAdd = _context.Add(ordertoAdd).Entity;
            _context.SaveChanges();
            foreach (Models.LineItem item in order.LineItems)
            {
                Entity.LineItem itemToAdd = new Entity.LineItem()
                {
                    StoreId = store.StoreFrontId,
                    ProductId = item.ProductId,
                    ItemQuantity = (int)item.ItemQuantity,
                    OrderId = ordertoAdd.Id
                };
                itemToAdd = _context.Add(itemToAdd).Entity;
                Entity.Inventory updatedInventory = _context.Inventories.FirstOrDefault(i => i.Id == item.InventoryId);
                updatedInventory.Quantity -= item.ItemQuantity;
                _context.Update(updatedInventory);
            }
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
                order.Id = ordertoAdd.Id;

            return order;
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

        public List<Models.PlacedOrder> CustOrderHist()
        {
            return _context.Orders.Where(order => order.CustomersId == Models.Customer.update).Select(old => new Model.PlacedOrder(){
                    Id = old.Id,
                    CustomerId = old.CustomersId,
                    StoreFrontId = old.StoreFrontId
                }
            ).ToList();
        }

        public List <Models.Order> OrderHistory()
        {
            return _context.Orders.Where(order => order.StoreFrontId == Models.StoreFront.update).Select(old => new Model.Order(){
                    Id = old.Id,
                    CustomersId = old.CustomersId,
                    StoreFrontId = old.StoreFrontId
            }
            ).ToList();
        }

        public Models.StoreFront GetStore(int StoreFrontId)
        {
            Entity.StoreFront getStore = _context.StoreFronts.Include(x => x.Inventories).FirstOrDefault(x => x.Id == StoreFrontId);

            return new Models.StoreFront()
            {
                StoreFrontId = getStore.Id,
                StoreFrontName = getStore.StoreFrontName,
                Inventory = getStore.Inventories.Select(x => new Models.Inventory()
                {
                    StoreId = (int)x.StoreId,
                    ProductId = (int)x.ProductId,
                    Quantity = (int)x.Quantity
                }).ToList()
            
            };
        }

        public Model.PlacedOrder PlaceOrder(Models.PlacedOrder finalorder)
        {
            Entity.Order toAdd = new Entity.Order();
            toAdd.CustomersId = finalorder.CustomerId;
            toAdd.StoreFrontId = finalorder.StoreFrontId;
            toAdd = _context.Orders.Add(toAdd).Entity;
            _context.SaveChanges();
            finalorder.Id = toAdd.Id;
            return finalorder;
        }

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

        public List<Customer> SearchCustomer(string querycust)
        {
            return _context.Customers.Where(
                customer => customer.Name.Contains(querycust)
            ).Select(
                c => new Models.Customer()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Age = c.Age
                }
            ).OrderBy(c => c.Name).ToList();
        }

        public Models.Inventory placeitems(Models.Inventory quantity)
        {
            Entity.Inventory toAdd = new Entity.Inventory();
            toAdd.Quantity = quantity.Quantity;
            toAdd.ProductId = quantity.ProductId;
            toAdd = _context.Inventories.Add(toAdd).Entity;
            _context.SaveChanges();
            quantity.StoreId = toAdd.Id;
            return quantity;
        }

        Product IRepo.UpdateInventory(Inventory productToUpdate)
        {
            throw new NotImplementedException();
        }

        public Models.Product GetAllProducts(int Id){
            Entity.Product getAllProducts = _context.Products.FirstOrDefault(p => p.Id == Id);
            return new Models.Product()
            {
                ProductId = getAllProducts.Id,
                Name = getAllProducts.Name,
                Genre = getAllProducts.Genre,
                Price = getAllProducts.Price,
                StoreQuantity = getAllProducts.Quantity,
                Inventory = getAllProducts.Inventories.Select(x => new Models.Inventory()
                {
                    StoreId = (int)x.StoreId,
                    ProductId = (int)x.ProductId,
                    Quantity = (int)x.Quantity
                }).ToList()
        };
    }
    }
}