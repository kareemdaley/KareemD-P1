using System;
namespace CreateAPI.App
{
    public class Transaction
    {

        public string orderID { get; set; }
        public int orderTotal { get; set; }
        public string Buyer { get; set; }
        public string Store { get; set; }
        
        public Transaction(string orderid, string buyer, int ordertotal , string store)
        {
            orderID = orderid;
            orderTotal = ordertotal;
            Buyer = buyer;
            Store = store;
        }

    }
}


