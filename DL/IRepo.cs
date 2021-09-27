using System.Collections.Generic;
using Models;
using System;

namespace DL
{
    public interface IRepo
    {
        List<StoreFront> GetAllStoreFronts();

        List<Customer> GetAllCustomers();

        // List<Review> GetAllReviews(); // can take out if necessary 

        List<Product> GetAllProducts();

        //List<LineItem> GetAllLineItems();

        Customer AddCustomer(Customer cust); // added with the help of nick 

        Product AddProduct(Product prod);
        
        StoreFront AddStoreFront(StoreFront loc);

        LineItem AddLineItem(LineItem line);

        // Review AddReview(Review rev);

        Product UpdateProduct(Product productToUpdate);

        Customer loginCustomer(Customer cust);

        // Order AddOrder (Order ord);

        // List<Order> GetAllOrders(Order ord);

        }
    }
