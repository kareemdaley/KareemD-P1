using System;
namespace CreateAPI.App
{
    public class Transaction
    {

        // ex: [ 10/7 Computer: Rock VS You: Paper => You Win! ]

        public string Buyer { get; set; }
        public string Item { get; set; }
        public string orderID { get; set; }
        public string Store { get; set; }
        public int orderTotal { get; set; }

        // constructor
        public Transaction(string orderid, string buyer, string item, string store)
        {

            Buyer = buyer;
            Item = item;
            orderID = orderid;
            Store = store;
        }
        public Transaction(string orderid, string buyer, string store, int ordertotal)
        {
            Buyer = buyer;
            orderID = orderid;
            Store = store;
            orderTotal = ordertotal;
        }

    }
}


