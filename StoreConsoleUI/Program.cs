
//using System.Text.Json;
//using ThisProject.Dtos;
using ThisProject.StoreLogic;

namespace ThisProject
{
    public class Program
    {

        public async static Task Main(string[] args)
        {

            Console.WriteLine("Welcome...Name?");
            string? name = null;
            while (name == null || name.Length <= 0)
            {
                Console.WriteLine("Enter valid name: ");
                name = Console.ReadLine();
            }
            try
            {
                await StoreService.newUser(name);
            }
            catch(Exception)
            {

            }
           
            //=========Stores Creates & Products Loaded in==============//
            Store GeneralSupply = new Store("GeneralSupply");
            Store ProShop = new Store("ProShop");
            Store QuikMart = new Store("QuikMart");
            try
            {
                await GeneralSupply.getProductsAsync();
                await ProShop.getProductsAsync();
                await QuikMart.getProductsAsync();
            }
            catch(Exception)
            {

            }

            Shopping.startShopping(name, GeneralSupply, ProShop, QuikMart);
            

        }

        public static void displayStores()
        {
            // list of store - print out using for each
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("                                ");
            Console.WriteLine("General Supply}           Press 1");
            Console.WriteLine("ProShop                  Press 2");
            Console.WriteLine("QuikMart                 Press 3");
            Console.WriteLine("================================");
            Console.WriteLine("Choose a store to shop in!\n" +
                                "Press 4 to see your items.\n" +
                                "Press 5 to see recent orders\n" +
                                "\nPress 0 to end program.\n");

        }
    }
}


