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

        Customer AddCustomer(Customer cust); // added with the help of nick 

        Product AddProduct(Product prod);
        
        StoreFront AddStoreFront(StoreFront loc);

        LineItem AddLineItem(LineItem line);

        PlacedOrder PlaceOrder(PlacedOrder order);


        Product UpdateProduct(Product productToUpdate);

        Customer loginCustomer(Customer cust);


        // Order AddOrder (Order ord);

        // List<Order> GetAllOrders(Order ord);
        //Customer SearchCustomer(string searchCustomer);
        List <Models.StoreFront> StoreLocation();

        }
    }
