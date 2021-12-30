using System;
namespace CreateAPI.App
{
	public interface IRepository
    {
        //IEnumerable<Transaction> GetAllTransactions(string name);
        Task<IEnumerable<Transaction>> GetOrderDetailsAsync(string name);
        Task<IEnumerable<Product>> GetProductsAsync(string name);
        Task<IEnumerable<User>> GetUsersAsync();
        //void AddNewUser(string user);
        //void AddNewTransaction(string orderID, string buyer, string item, string store);
        //int getInventory(string item);
        //void setInventory(string item, int numLeft);
        //void AddNewTransaction(string orderID, string buyer, string storeName, int total);
    }
}

