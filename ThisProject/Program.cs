
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
            await StoreService.newUser(name);
           
            //=========Stores Creates & Products Loaded in==============//
            Store GeneralSupply = new Store("GeneralSupply");
            await GeneralSupply.getProductsAsync();
            Store ProShop = new Store("ProShop");
            await ProShop.getProductsAsync();
            Store QuikMart = new Store("QuikMart");
            await QuikMart.getProductsAsync();

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


