
using DL;
using StoreBL;
using System;
using System.IO;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuString)
        {
    

    //         // IRepo dataLayer = new FileRepo();
    //         // IBL businessLogic = new BL(dataLayer);
    //         // IMenu restaurantMenu = new RestaurantMenu(businessLogic);

    //         // restaurantMenu.Start();
            switch (menuString.ToLower())
            {

                case "main":
                    return new MainMenu();//new BL(new FileRepo()));
                //case "Admin":
                    //return new AdminMenu(new BL(new FileRepo())); //no break statements because we are returning out of all of these options
                case "register":
                    return new Registration(new BL(new FileRepo()));
                case "inventory":
                    return new InventoryMenu(new BL(new FileRepo()));
                case "review":
                    return new ReviewMenu(new BL(new FileRepo()));
                default:
                    return null;
            }
        }
    }
}
    

