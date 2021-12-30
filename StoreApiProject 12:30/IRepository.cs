using System;
namespace CreateAPI.App
{
	public interface IRepository
    {
        //IEnumerable<Transaction> GetAllTransactions(string name);
        //void AddNewTransaction(string orderID, string buyer, string item, string store);
        Task<IEnumerable<Transaction>> GetOrderDetailsAsync(string name);
        //void AddNewTransaction(string orderID, string buyer, string storeName, int total);
        Task<IEnumerable<Product>> GetProductsAsync(string name);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<User>> AddNewUserAsync(string user);
        Task<IEnumerable<Product>> SetInventoryAsync(string item, int numLeft);


        //int getInventory(string item);
    }
}

