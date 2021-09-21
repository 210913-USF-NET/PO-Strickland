using System;
using StoreBL;

namespace UI
{
    public class MainMenu : IMenu //we implement IMenu which contains the start method for the user 
    {
        //main menu needs ways to access BL
        private IBL _bl;
        public MainMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            Console.WriteLine("This is Main Menu");
        }
    }
}