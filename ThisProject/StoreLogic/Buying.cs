using System;
namespace ThisProject.StoreLogic
{
	public class Buying
	{
		public Buying()
		{
		}

        public static bool buying(bool stillBuying, string orderID, string buyer, int[] order, Store Brand)
        {

            //_repository.setInventory(Products[0].Title, Products[0].numLeft);
            //_repository.setInventory(Products[1].Title, Products[1].numLeft);
            //_repository.setInventory(Products[2].Title, Products[2].numLeft);
            Console.WriteLine("What would you like to buy? \n" +
                "Press 4 to see store's order history.\nPress 0 to exit.");
            int choice;
            bool tryChoice = int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:

                    if (Brand.Products[0].numLeft == 0)
                    {
                        Console.WriteLine("I can't fill that");
                        return stillBuying;
                    }
                    order[0]++;
                    Brand.Products[0].numLeft--;
                    //AddRecord(orderID, buyer, Products[0].Title, StoreName);
                    return stillBuying;
                case 2:
                    if (Brand.Products[1].numLeft == 0)
                    {
                        Console.WriteLine("I can't fill that");
                        return stillBuying;
                    }
                    order[1]++;
                    Brand.Products[1].numLeft--;
                    //AddRecord(orderID, buyer, Products[1].Title, StoreName);
                    return stillBuying;
                case 3:
                    if (Brand.Products[2].numLeft == 0)
                    {
                        Console.WriteLine("I can't fill that");
                        return stillBuying;
                    }
                    order[2]++;
                    Brand.Products[2].numLeft--;
                    //AddRecord(orderID, buyer, Products[2].Title, StoreName);
                    return stillBuying;
                case 4:
                    Console.Clear();
                    //_repository.GetOrderDetails(StoreName);
                    Console.ReadLine();
                    return !stillBuying;
                default:
                    return !stillBuying;


            }


        }
    }
}

