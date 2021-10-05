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
        StoreFront GetStore(int StoreFrontId);
    //******************************************************************
        List<Customer> GetAllCustomers(); //change if doesnt work 

        Customer AddCustomer(Customer cust); //added with the help of nick 

    //*******************************************************************
        List<Product> GetAllProducts();
        Product GetAllProducts(int Id);

        Product AddProduct(Product prod);
    //********************************************************************

        Product UpdateInventory(Inventory productToUpdate );

        Models.Inventory placeitems(Models.Inventory quantity);
    //********************************************************************

        void loginCustomer(Customer customer);


        List<Order> GetAllOrders(); //change if doesnt work 

        void AddOrder(Order ord); //added with the help of nick 


        List<LineItem> GetAllLineItems(); //change if doesnt work 
        List<Inventory> GetAllInventory();
        LineItem AddLineItem(LineItem line); 

        Order CreateCart(int customerId, int StoreId);
        Order PlaceOrder(Order order, StoreFront store);

        List<Inventory> ListInventoryByStore(int StoreFrontId);

        
    }

    /*
    when we have an interface (same is true for interface in Models, UI, DL)
    these members are public by default. This way we don't have to have 
    access modifier in front of it
    */
}