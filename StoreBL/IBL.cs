using System.Collections.Generic;
using Models;

namespace StoreBL
{
    public interface IBL
    {
    //******************************************************************
        List<StoreFront> GetAllStoreFronts();

        StoreFront AddStoreFront(StoreFront loc);
    //******************************************************************

    //******************************************************************
        List<Customer> GetAllCustomers(); //change if doesnt work 

        Customer AddCustomer(Customer cust); //added with the help of nick 

    //*******************************************************************
        List<Product> GetAllProducts();

        Product AddProduct(Product prod);
    //********************************************************************

        Product UpdateProduct(Product productToUpdate );
    
    //********************************************************************

        void loginCustomer(Customer customer);


        List<Order> GetAllOrders(); //change if doesnt work 

        void AddOrder(Order ord); //added with the help of nick 


        List<LineItem> GetAllLineItems(); //change if doesnt work 

        LineItem AddLineItem(LineItem line); 
        
    }

    /*
    when we have an interface (same is true for interface in Models, UI, DL)
    these members are public by default. This way we don't have to have 
    access modifier in front of it
    */
}