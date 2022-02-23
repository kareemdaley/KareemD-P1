using System;
namespace CreateAPI.App
{
	public interface IRepository
    {
        //IEnumerable<Transaction> GetAllTransactions(string name);
        //void AddNewTransaction(string orderID, string buyer, string item, string store);
        Task<IEnumerable<Transaction>> GetOrderDetailsAsync(string name);
        Task<IEnumerable<Transaction>> AddNewOrderAsync(string orderID, string buyer, string store, int ordertotal);
        //void AddNewTransaction(string orderID, string buyer, string storeName, int total);
        Task<IEnumerable<Product>> GetProductsAsync(string name);
        Task<IEnumerable<User>> GetUsersAsync(string name);
        Task<IEnumerable<User>> AddNewUserAsync(string user);
        Task<IEnumerable<Product>> SetInventoryAsync(string item, int numLeft);


        //int getInventory(string item);
    }
}

