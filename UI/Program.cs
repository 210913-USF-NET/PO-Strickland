using System;
using Models;
using StoreBL;
using DL;
using Serilog;

namespace UI
{
    class Program
    {

        static void Main(string[] args)
        {
            // //using block is used to limit the scope of a thing to this particular block
            // using(){ var logger = new LoggerConfiguration()  
            // .MinimumLevel.Debug()
            // .WriteTo.Console()
            // .WriteTo.File("../logs/logs.txt", rollingInterval: RollingInterval.Day)
            // .CreateLogger();
            // //this will give me access to logger, but once I exit, the logger is disposed
            // }

        Log.Logger = new LoggerConfiguration() //this is static 
            //log configuration to take in new logs from main method
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("../logs/logs.txt", rollingInterval: RollingInterval.Day) //store in console folder
            .CreateLogger();
            Log.Information("Application Starting..");
            


            Console.WriteLine("\nWelcome to My Store!");
            StoreFront myStore = new StoreFront(){
                StoreFrontName = "Lucky Disks",
                Address = "2400 Elders Rd, Charlotte, NC\n"
            };
            Console.WriteLine(myStore.ToString());

            MenuFactory.GetMenu("main").Start();
            
            
            //main menu needs a instance of business logic 

            Log.Information("Application closing.."); //once the main menu has exited 
            Log.CloseAndFlush(); //because this is a unmanaged resource, we need to close it by ourselves
        }
    }
}