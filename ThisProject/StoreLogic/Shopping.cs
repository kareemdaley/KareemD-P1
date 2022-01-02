using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ThisProject.StoreLogic
{
	public class Shopping
	{
		string Customer;

		public Shopping(string customer)
		{
			Customer = customer;
		}

		
		public static void startShopping(string customer, Store a, Store b, Store c)
		{
            bool isShopping = true;
            while (isShopping)
            {
                Program.displayStores();
                int chooseStore;



                do
                {
                    bool tryChoice = int.TryParse(Console.ReadLine(), out chooseStore);

                } while (chooseStore != 1 && chooseStore != 2 &&
                        chooseStore != 3 && chooseStore != 4 &&
                        chooseStore != 9 && chooseStore != 0 && chooseStore != 5);

                switch (chooseStore)
                {
                    case 1:
                        PlaceOrder.placeOrder(customer, a);
                        break;
                    case 2:
                        PlaceOrder.placeOrder(customer, b);
                        break;
                    case 3:
                        PlaceOrder.placeOrder(customer, c);
                        break;
                    //case 4:
                    //    repository.GetAllTransactions(customer);
                    //    string bin = Console.ReadLine();
                    //    break;
                    //case 5:
                    //    repository.GetOrderDetails(customer);
                    //    string btin = Console.ReadLine();
                    //    break;
                    //case 9:
                    //    displayStores();
                    //    GeneralSupply.Products[0].numLeft += 5;
                    //    GeneralSupply.Products[1].numLeft += 5;
                    //    GeneralSupply.Products[2].numLeft += 5;
                    //    ProShop.Products[0].numLeft += 5;
                    //    ProShop.Products[1].numLeft += 5;
                    //    ProShop.Products[2].numLeft += 5;
                    //    QuikMart.Products[0].numLeft += 5;
                    //    QuikMart.Products[1].numLeft += 5;
                    //    QuikMart.Products[2].numLeft += 5;
                    //    Console.WriteLine("Stores are restocked!");
                    //    string non = Console.ReadLine();
                    //    break;
                    case 0:
                        isShopping = false;
                        break;
                    default:
                        isShopping = false;
                        break;
                }

            }

        }




	}

	
}

