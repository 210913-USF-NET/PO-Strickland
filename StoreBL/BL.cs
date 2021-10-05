using System;
using System.Collections.Generic;
using DL;
using Models;

namespace StoreBL //never have the namespace title the same as the public class title. This will cause an error. 
//also name title is StoreBL. We use this when connecting to other projects with 'using' keyword
//thus, 'using StoreBL;' in other parts of the program. 
{
    public class BL : IBL
    {
        private IRepo _repo;

        //dependency injection
        public BL(IRepo repo) 
        {
            _repo = repo;
        }
        //*********************************************************
        public StoreFront AddStoreFront(StoreFront loc)
        {
            return _repo.AddStoreFront(loc);

        }
        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }
        //*********************************************************
        public StoreFront GetStore(int StoreFrontId)
        {
            return _repo.GetStore(StoreFrontId);
        }
        //**********************************************************

        public Customer AddCustomer(Customer cust)
        { //added with the help of nick 

            return _repo.AddCustomer(cust); // going to DL
        }


        public Product AddProduct(Product prod)
        {

            return _repo.AddProduct(prod); // going to DL
        }
        public List<Inventory> ListInventoryByStore(int StoreFrontId){
            return _repo.ListInventoryByStore(StoreFrontId);
        }

        // public void AddStoreFront(StoreFront loc)
        // { //added with the help of nick 

        //     _repo.AddStoreFront(loc); // going to DL
        // }

        public List<Customer> GetAllCustomers() //Change if doesnt work 
        {
            return _repo.GetAllCustomers();
        }
        //***********************************************************


        //public Product AddProduct(Product prod) => _repo.AddProduct(prod); // going to DL


        //*************************************************************
        public List<Product> GetAllProducts() //Change if doesnt work 
        {
            return _repo.GetAllProducts();
        }
        public Product GetAllProducts(int Id){
            return _repo.GetAllProducts(Id);
        }
        //*************************************************************

        public Product UpdateInventory(Inventory productToUpdate )

        {
            return _repo.UpdateInventory(productToUpdate);
        }

        public Models.Inventory placeitems(Models.Inventory quantity){
            return _repo.placeitems(quantity);
        }

        //*************************************************************
        public void loginCustomer(Customer cust){
            _repo.loginCustomer(cust);
        }


        public void AddOrder(Order ord)
        { //added with the help of nick 

           return; // going to DL
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        // public void List<Order> AddOrder()
        // {
        //     return;
        // }

        public LineItem AddLineItem(LineItem line)
        {
            return _repo.AddLineItem(line);

        }

        public Order CreateCart(int customerId, int StoreId)
        {
            return _repo.CreateCart(customerId, StoreId);
        }


        public List<LineItem> GetAllLineItems()
        {
            return _repo.GetAllLineItems();
        }

        // public List<Product> GetAllProducts() //Change if doesnt work 
        // {
        //     return _repo.GetAllProducts();
        // }

        
        public Order PlaceOrder(Order order, StoreFront store)
        {
            return _repo.PlaceOrder(order, store);
        }

        public List<Inventory> GetAllInventory(){
            return _repo.GetAllInventory();
        }
        
    }
}
    /*
    when we actually implement the interface, we have to declare the
    access modifer, we have to have these as public. 
    */