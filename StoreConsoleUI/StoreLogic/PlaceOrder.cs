using System;
namespace ThisProject.StoreLogic
{
	public class PlaceOrder
	{
		string Customer;
        Store Brand;
	
		public PlaceOrder(string customer, Store x)
		{
			Customer = customer;
            this.Brand = x;


		}

        public static int placeOrder(string buyer, Store Brand)
        {
            int total = 0;
            int[] order = { 0, 0, 0 };
            bool stillBuying = true;
            string Rand = Guid.NewGuid().ToString("N").Substring(0, 5);
            string orderID = Rand;
            do
            {
                Brand.menu();
                GetTotal.Total(order);
                stillBuying = Buying.buying(stillBuying, orderID, buyer, order, Brand);
            }
            while (stillBuying);
            total = GetTotal.Total(order);
            //_repository.AddNewTransaction(orderID, buyer, StoreName, total);
            return GetTotal.Total(order);
        }
    }
}

