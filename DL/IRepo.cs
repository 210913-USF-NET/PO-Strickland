using System.Collections.Generic;
using Models;
using System;

namespace DL
{
    public interface IRepo
    {
        List<StoreFront> GetAllStoreFronts();

        List<Customer> GetAllCustomers();


        List<Product> GetAllProducts();

        List<LineItem> GetAllLineItems();

        List<Inventory> GetAllInventory();

        Customer AddCustomer(Customer cust); // added with the help of nick 

        Product AddProduct(Product prod);
        StoreFront GetStore(int StoreFrontId);
        
        StoreFront AddStoreFront(StoreFront loc);

        LineItem AddLineItem(LineItem line);

        PlacedOrder PlaceOrder(PlacedOrder order);


        Product UpdateInventory(Inventory productToUpdate);

        Models.Inventory placeitems(Models.Inventory quantity);

       // public Inventory UpdateInventory(Inventory productToUpdate);

        Customer loginCustomer(Customer cust);

        List<Inventory> ListInventoryByStore(int StoreFrontId);


        // Order AddOrder (Order ord);

        // List<Order> GetAllOrders(Order ord);
        // Customer SearchCustomer(string searchCustomer);
        List <Models.StoreFront> StoreLocation();
        Order PlaceOrder(Order order, StoreFront store);
        Order CreateCart(int customerId, int StoreId);

        Product GetAllProducts(int Id);

        Product GetOneProductById(int Id);

        StoreFront GetOneStoreById(int Id);

    }
    }
