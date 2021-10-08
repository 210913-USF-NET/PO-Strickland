using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Model = Models; //this is how you give an alias to a namespace
//using Entity = DL.Entities; //this is how you give an alias to a namespace
using Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;



namespace DL
{
    public class DBRepo : IRepo
    {
        //this needs dbcontext 
        private P1DBContext _context;


        //and these methods will get data from db
        public DBRepo(P1DBContext context){
            _context = context; //whatever is passed in, we will save to our private field 
        }
        //and persist to db 
        public Customer AddCustomer(Customer cust) //now we know that we are calling customer models 
        {
            Customer customerToAdd = new Customer(){
                Name = cust.Name,
                Age = cust.Age,
                Email = cust.Email
                
            }; //when I create a new product, there is no Id. DB will assign it for me

            customerToAdd = _context.Customers.Add(customerToAdd).Entity; //this method tracks what object is being added
            _context.SaveChanges(); //this method will send it to the database. "changes" are not executed util you call the SaveChanges method
            _context.ChangeTracker.Clear();//it tracks entity, so call this. This clears the changeTracker method so it returns to a clean slate. 

            return new Customer(){
                CustomerId = customerToAdd.Id,
                Name = customerToAdd.Name,
                Age = customerToAdd.Age,
                Email = customerToAdd.Email
                
            };
        }

        public LineItem AddLineItem(LineItem line)
        {
            LineItem LineItemToAdd = new LineItem(){
                ItemQuantity = line.ItemQuantity
                
            }; 

            LineItemToAdd = _context.LineItems.Add(LineItemToAdd).Entity;
            _context.SaveChanges(); 
            _context.ChangeTracker.Clear(); 

            return new LineItem(){
                LineItemId = LineItemToAdd.Id,
                ItemQuantity = LineItemToAdd.ItemQuantity
            };
        }

        public Product AddProduct(Product prod)
        {
            //Product productToAdd = new Product(){
            //    Name = prod.Name,
            //    Price = prod.Price,
            //    Genre = prod.Genre
            //}; 

            //productToAdd = _context.Products.Add(productToAdd).Entity;
            //_context.SaveChanges(); 
            //_context.ChangeTracker.Clear(); 

            //return new Product(){
            //    ProductId = productToAdd.ProductId,
            //    Name = productToAdd.Name,
            //    Price = productToAdd.Price,
            //    Genre = productToAdd.Genre
            //};

            //since we are not mapping anymore, all we need is this (Below) to add to database. 
            prod = _context.Add(prod).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return prod;
        }

        public StoreFront AddStoreFront(StoreFront loc)
        {
            //StoreFront storeFrontToAdd = new StoreFront(){
            //    StoreFrontName = loc.StoreFrontName,
            //    Address = loc.Address
            //}; 

            //storeFrontToAdd = _context.StoreFronts.Add(storeFrontToAdd).Entity; 
            //_context.SaveChanges(); 
            //_context.ChangeTracker.Clear(); 

            //return new StoreFront(){
            //    StoreFrontId = storeFrontToAdd.StoreFrontId,
            //    StoreFrontName = storeFrontToAdd.StoreFrontName,
            //    Address = storeFrontToAdd.Address
            //};
            loc = _context.Add(loc).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return loc;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                Customer => new Customer(){
                    CustomerId = Customer.Id,
                    Name = Customer.Name,
                    Age = Customer.Age,
                    Email = Customer.Email
                    
                }
            ).ToList();
        }

        public List<Inventory> GetAllInventory()
        {
            return _context.Inventory.Select(
                Inventory => new Inventory(){
                    Id = Inventory.Id,
                    StoreId = Inventory.StoreId,
                    ProductId = Inventory.ProductId,
                    Quantity = (int)Inventory.Quantity
                    
                }
            ).ToList();
        }

        public List<LineItem> GetAllLineItems()
        {
            return _context.LineItems.Select(
                LineItem => new LineItem(){
                    LineItemId = LineItem.Id,
                    ItemQuantity = LineItem.ItemQuantity
                }
            ).ToList();
        }

        public List<Product> GetAllProducts()
        {
            //select * from in sql query
            return _context.Products.Select(
                Product => new Product(){
                    ProductId = Product.ProductId,
                    Name = Product.Name,
                    Price = Product.Price,
                    Genre = Product.Genre
                }
            ).ToList();
        }
            
        public List<StoreFront> GetAllStoreFronts()
        {
            return _context.StoreFronts.Select(
                StoreFront => new StoreFront(){
                    StoreFrontId = StoreFront.StoreFrontId,
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

        public Order CreateCart(int CustomersId, int StoreId)
        {
            // Entity.Order cart = new Entity.Order() { };
            // cart.CustomerId = CustomerId;
            Order cart = new Order()
            {
                CustomersId = CustomersId,
                StoreFrontId = StoreId,
            };
            cart = _context.Add(cart).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Order()
            {
                Id = cart.Id,
                CustomersId = (int)cart.CustomersId,
                StoreFrontId = (int)cart.StoreFrontId
            };
        }
        //Select * FROM Inventory JOIN PRODUCT ON Product.Id = Inventory.ProductId
        
        public List<Inventory> ListInventoryByStore(int StoreFrontId)
        {
            return _context.Inventory.Include("Product").Where(i => i.StoreId == StoreFrontId ).Select(
                Inventory => new Inventory(){
                    Id = Inventory.Id,
                    StoreId = Inventory.StoreId,
                    ProductId = Inventory.ProductId,
                    Quantity = (int)Inventory.Quantity,
                    Item = new Product (){
                        ProductId = Inventory.Product.ProductId,
                        Name = Inventory.Product.Name,
                        Genre = Inventory.Product.Genre,
                        Price = Inventory.Product.Price,
                        StoreQuantity = Inventory.Product.StoreQuantity
                    }
                }
            ).ToList();
        }
        
        /*
         public List<Inventory> ListInventoryByStore(int StoreFrontId)
        {
            return _context.Inventories.Include("Product").Where(i => i.StoreId == StoreFrontId ).Select(
                Inventory => new Inventory(){
                    Id = Inventory.Id,
                    StoreId = Inventory.StoreId,
                    ProductId = Inventory.ProductId,
                    Quantity = (int)Inventory.Quantity,
                    Item = new Product (){
                        ProductId = Inventory.Product.Id,
                        Name = Inventory.Product.Name,
                        Genre = Inventory.Product.Genre,
                        Price = Inventory.Product.Price,
                        StoreQuantity = Inventory.Product.Quantity
                    }
                }
            ).ToList();
        }
        */


        public Order PlaceOrder(Order order, StoreFront store)
        {
            Order ordertoAdd = new Order(){
                StoreFrontId = order.StoreFrontId,
                CustomersId = order.CustomersId
            };
            ordertoAdd = _context.Add(ordertoAdd).Entity;
            _context.SaveChanges();
            foreach (LineItem item in order.LineItems)
            {
                LineItem itemToAdd = new LineItem()
                {
                    StoreId = store.StoreFrontId,
                    ProductId = item.ProductId,
                    ItemQuantity = (int)item.ItemQuantity,
                    OrderId = ordertoAdd.Id
                };
                itemToAdd = _context.Add(itemToAdd).Entity;
                Inventory updatedInventory = _context.Inventory.FirstOrDefault(i => i.Id == item.InventoryId);
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
        public List<Product> ListOfProducts()
        {
            return _context.Products.Select(
                Product => new Product() {
    
                    Name = Product.Name,
                    Price = Product.Price
                    
                }
            ).ToList();

        }


        public LineItem CheckOutList(LineItem line)
        {
            LineItem toAdd = new LineItem();
            toAdd.ItemQuantity = line.ItemQuantity;
            toAdd.ProductId = line.ProductId;
            toAdd = _context.LineItems.Add(toAdd).Entity;
            _context.SaveChanges();
            line.Id = toAdd.Id;
            return line;
        }

        public List<PlacedOrder> CustOrderHist()
        {
            return _context.Orders.Where(order => order.CustomersId == Customer.update).Select(old => new PlacedOrder(){
                    Id = old.Id,
                    CustomerId = old.CustomersId,
                    StoreFrontId = old.StoreFrontId
                }
            ).ToList();
        }

        public List <Order> OrderHistory()
        {
            return _context.Orders.Where(order => order.StoreFrontId == StoreFront.update).Select(old => new Order(){
                    Id = old.Id,
                    CustomersId = old.CustomersId,
                    StoreFrontId = old.StoreFrontId
            }
            ).ToList();
        }
        
        public StoreFront GetStore(int StoreFrontId)
        {
            StoreFront getStore = _context.StoreFronts.Include(x => x.Inventory).FirstOrDefault(x => x.StoreFrontId == StoreFrontId);

            return new StoreFront()
            {
                StoreFrontId = getStore.StoreFrontId,
                StoreFrontName = getStore.StoreFrontName,
                Inventory = getStore.Inventory.Select(x => new Inventory()
                {
                    StoreId = (int)x.StoreId,
                    ProductId = (int)x.ProductId,
                    Quantity = (int)x.Quantity
                }).ToList()
            
            };
        }
        
        public PlacedOrder PlaceOrder(PlacedOrder finalorder)
        {
            Order toAdd = new Order();
            toAdd.CustomersId = finalorder.CustomerId;
            toAdd.StoreFrontId = finalorder.StoreFrontId;
            toAdd = _context.Orders.Add(toAdd).Entity;
            _context.SaveChanges();
            finalorder.Id = toAdd.Id;
            return finalorder;
        }

        public List <StoreFront> StoreLocation()
        {
            return _context.StoreFronts.Select(
                StoreFronts => new StoreFront() {
    
                    StoreFrontId = StoreFronts.StoreFrontId,
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
                c => new Customer()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Age = c.Age
                }
            ).OrderBy(c => c.Name).ToList();
        }

        public Inventory placeitems(Inventory quantity)
        {
            Inventory toAdd = new Inventory();
            toAdd.Quantity = quantity.Quantity;
            toAdd.ProductId = quantity.ProductId;
            toAdd = _context.Inventory.Add(toAdd).Entity;
            _context.SaveChanges();
            quantity.StoreId = toAdd.Id;
            return quantity;
        }

        Product IRepo.UpdateInventory(Inventory productToUpdate)
        {
            throw new NotImplementedException();
        }

        
        public Product GetAllProducts(int Id){
            Product getAllProducts = _context.Products.FirstOrDefault(p => p.ProductId == Id);
            return new Product()
            {
                ProductId = getAllProducts.ProductId,
                Name = getAllProducts.Name,
                Genre = getAllProducts.Genre,
                Price = getAllProducts.Price,
                StoreQuantity = getAllProducts.StoreQuantity,
                Inventory = getAllProducts.Inventory.Select(x => new Inventory()
                {
                    StoreId = (int)x.StoreId,
                    ProductId = (int)x.ProductId,
                    Quantity = (int)x.Quantity
                }).ToList()
        };
    }
        public Product GetOneProductById(int id)
        {
            return _context.Products
                .AsNoTracking()
                .Include(r => r.Inventory)
                .FirstOrDefault(r => r.ProductId == id);
        }

        public StoreFront GetOneStoreById(int id)
        {
            return _context.StoreFronts
                .AsNoTracking()
                .Include(r => r.Inventory)
                .FirstOrDefault(r => r.StoreFrontId == id);
        }
    }
}