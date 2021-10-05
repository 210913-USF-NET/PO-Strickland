   
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Models;
// using System.Text.Json;
// using System.IO;

// namespace DL
// { 
//     // Implement IRepo using singleton design pattern
//     // SDP is used if you want one instance of something regardless of where it is 
//     //need non access modifer of sealed to make this work
//     //sealed means class is no longer inheritable
//     public sealed class RAMRepo : IRepo
//     {
//         private static RAMRepo _instance; //only I can access this instance. NO ONE ELSE CAN. We have an instance

//     //************************************************************************************************************ 
//         private RAMRepo()
//         {

//             _storeFront = new List<StoreFront>()
//             {
//                 new StoreFront()
//                 {
//                     Name = "Lucky Disks at Charlotte",
//                     Address = "2980 Park Rd, Charlotte, NC"
//                 }
//             };

//             _customer = new List<Customer>(){
//                 new Customer()
//                 {
//                     Name = "Trey",
//                     Age = 30,
//                     Email = "ctstrick61@gmail.com"
//                 }
//             };

//             _product = new List<Product>(){
//                 new Product()
//                 {
//                     Name = "It",
//                     Price = 10,
//                     Genre = "Horror",
//                     //Quantity = "15"
//                     Quantity = 15
//                 }
//             };

//             _line = new List<LineItem>(){
//                 new LineItem(){

//                     Name = "IT",
//                     Quantity = 2,
//                     Email = "ctstrick61@gmail.com"
//                 }


//             };
//         }
//     //************************************************************************************************************

//         // private static RAMRepo _instance; //only I can access this instance. NO ONE ELSE CAN. We have an instance

//         public static RAMRepo GetInstance(){ // a constructor to return the instance 

//             if(_instance == null) //if there is nothing, then we will instantiate for it
//             {
//                 _instance = new RAMRepo();
//             }
//             return _instance; //if not, then return what is there already
//         }

//     //***********************************************************************************************************
//     //***********************************************************************************************************
//         private static List<Customer> _customer;

//         public Customer AddCustomer (Customer cust){
//             _customer.Add(cust);
//             return cust;
//         }

//         public Customer loginCustomer (Customer cust){
//             _customer.Add(cust);
//             return cust;

//         }
        

//         public List<Customer> GetAllCustomers(){
//             return _customer;
//         }
//     //******************************************************************
//         private static List<StoreFront> _storeFront;

//         public StoreFront AddStoreFront (StoreFront loc){
//             _storeFront.Add(loc);
//             return loc;
//         }

//         public List<StoreFront> GetAllStoreFronts(){
//             return _storeFront;
//         }
//     //******************************************************************
//         private List<Product> _product;

//         public Product AddProduct (Product prod){
//             _product.Add(prod);
//             return prod;
//         }

//         public List<Product> GetAllProducts(){
//             return _product;
//         }
//     //******************************************************************
//         private List<LineItem> _line;

//         public LineItem AddLineItem (LineItem line){
//             _line.Add(line);
//             return line;
//         }

//         public List<LineItem> GetAllLineItems(){
//             return _line;
//         }
//     //******************************************************************
//         public Product UpdateProduct(Product productToUpdate)
//         {
//             throw new NotImplementedException();
//         }
//     //***********************************************************************************************************

//     }
// }