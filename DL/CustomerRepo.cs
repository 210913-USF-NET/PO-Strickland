using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using System.Text.Json;
using System.IO;

namespace DL
{
    // public class CustomerRepo : ICustomerRepo
    // {
    //     private const string filePath = "../DL/Customers.json";

    //     private string jsonString;

    //     public Customer AddCustomer(Customer customer){

    //         List<Customer> allCustomer = GetAllCustomer();
    //         allCustomer.Add(customer);

    //         jsonString = JsonSerializer.serialize(allCustomer);
    //         File.WriteAllText(filePath, jsonString);
    //         return customer;
    //     }

    //     public void DeleteCustomer(string email){
    //         throw new System.NotImplementedException();
    //     }

    //     public List <customer> GetAllCustomer(){
    //         jsonString = File.ReadAllText(filePath);

    //         return JsonSerializer.Deserialize<List<Customer>>(jsonString);
    //     }

    //     public Customer GetCustomer(string email){
    //         throw new System.NotImplementedException();
    //     }

    //     public Customer AddAnOrder(Order order){
    //         throw new Exception();
    //     }
        
    // }
}