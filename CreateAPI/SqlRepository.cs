using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CreateAPI.App
{
    public class SqlRepository : IRepository
    {



        private readonly string _connectionString;

        public SqlRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        //public IEnumerable<Transaction> GetAllTransactions(string name)
        //{
        //    List<Transaction> result = new List<Transaction>();

        //    using SqlConnection connection = new(_connectionString);
        //    connection.Open();

        //    using SqlCommand cmd = new(
        //    @"SELECT * FROM shop.Orders WHERE orderName = @sortName OR storeRef = @sortName;",
        //        connection);

        //    cmd.Parameters.AddWithValue("@sortName", name);

        //    using SqlDataReader reader = cmd.ExecuteReader();

        //    // get trx from db
        //    while (reader.Read())
        //    {
        //        string id = reader["orderID"].ToString();
        //        string orderName = reader["orderName"].ToString();
        //        string item = reader["orderItem"].ToString();
        //        string store = reader["storeRef"].ToString();
        //        result.Add(new(id, orderName, item, store));
        //        Console.WriteLine($"Order id: {id} - {orderName} purchased {item}");

        //    }

        //    return result;
        //}

        public async Task<IEnumerable<Transaction>> GetOrderDetailsAsync(string name)
        {
            List<Transaction> result = new List<Transaction>();

            using SqlConnection connection = new(_connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                        @"SELECT * FROM shop.OrderSummary
                        WHERE store = @sortName
                        OR nameonOrder = @sortName;",
                connection);

            cmd.Parameters.AddWithValue("@sortName", name);

            using SqlDataReader reader = cmd.ExecuteReader();

            // get trx from db
            while (reader.Read())
            {
                string id = reader["ID"].ToString();
                string orderName = reader["nameonOrder"].ToString();
                string orderTotal = reader["orderTotal"].ToString();
                string store = reader["store"].ToString();
                result.Add(new(id, orderName, orderTotal, store));
                Console.WriteLine($"Order id: {id} - {orderName} Total ${orderTotal}");


            }

            return result;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(string name)
        {
            List<Product> result = new List<Product>();

            using SqlConnection connection = new(_connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                        @"SELECT * FROM shop.Items
                          WHERE store = @sortName
                          OR itemName = @sortName;
                         ",
                        
            connection);

            cmd.Parameters.AddWithValue("@sortName", name);

            using SqlDataReader reader = cmd.ExecuteReader();

            // get trx from db
            while (reader.Read())
            {
                string itemName = reader["itemName"].ToString();
                int price = (int)reader["itemPrice"];
                int inventory = (int)reader["Inventory"];
                string store = reader["store"].ToString();
                result.Add(new(itemName, price, inventory, store));
                Console.WriteLine($"{itemName} cost ${price} and there are {inventory} left at {store}");

            }

            return result;
        }

        public async Task<IEnumerable<Product>> SetInventoryAsync(string item, int numLeft)
        {
            List<Product> result = new List<Product>();

            using SqlConnection connection = new(_connectionString);
            connection.Open();

            string cmdText = @"UPDATE shop.Items 
                            SET Inventory = @numLeft 
                            WHERE itemName = @itemName;
                            SELECT * FROM shop.Items
                            WHERE itemName=@itemName;";
            using SqlCommand cmd = new(cmdText, connection);

            // ado.net requires you to use DBNull instead of null when you mean a SQL NULL value
            cmd.Parameters.AddWithValue("@numLeft", numLeft);
            cmd.Parameters.AddWithValue("@itemName", item);

            using SqlDataReader reader = cmd.ExecuteReader();

            // get trx from db
            while (reader.Read())
            {
                string itemName = reader["itemName"].ToString();
                int price = (int)reader["itemPrice"];
                int inventory = (int)reader["Inventory"];
                string store = reader["store"].ToString();
                result.Add(new(itemName, price, inventory, store));
                Console.WriteLine($"{itemName} cost ${price} and there are {inventory} left at {store}");

            }

            Console.WriteLine($"Inventory Updated");

            return result;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(string name)
        {
            List<User> result = new List<User>();

            using SqlConnection connection = new(_connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                        @"SELECT * FROM shop.Users WHERE userName=@sortName;",
                connection);

            cmd.Parameters.AddWithValue("@sortName", name);

            using SqlDataReader reader = cmd.ExecuteReader();

            // get trx from db
            while (reader.Read())
            {
                string Name = reader["userName"].ToString();
                string ID= reader["userID"].ToString();
                result.Add(new(Name, ID));
                Console.WriteLine($"{Name}'s userID: {ID}");

            }

            return result;
        }

        public async Task<IEnumerable<User>> AddNewUserAsync(string user)
        {
            List<User> result = new List<User>();
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"INSERT INTO shop.Users (userName)
                                SELECT * FROM(SELECT (@thisName) AS userName) AS temp
                                WHERE NOT EXISTS (Select *from shop.Users where userName = (@thisName));
                                SELECT * FROM shop.Users
                                WHERE userName=@thisName;";
            using SqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@thisName", user);

            using SqlDataReader reader = cmd.ExecuteReader();

            
            while (reader.Read())
            {
                string Name = reader["userName"].ToString();
                string ID = reader["userID"].ToString();
                result.Add(new(Name, ID));
                Console.WriteLine($"{Name}'s userID: {ID}");

            }

            return result;
        }

        






        //public void AddNewTransaction(string orderID, string buyer, string item, string store)
        //{
        //    using SqlConnection connection = new(_connectionString);
        //    connection.Open();

        //    // assume the order exist already in the DB
        //    string cmdText = @"INSERT INTO shop.Orders (orderName, orderID, orderItem, storeRef)
        //                       VALUES (  @thisName, @thisOrder , @orderItem, @storeRef)";
        //    using SqlCommand cmd = new(cmdText, connection);

        //    // ado.net requires you to use DBNull instead of null when you mean a SQL NULL value
        //    cmd.Parameters.AddWithValue("@thisName", buyer);
        //    cmd.Parameters.AddWithValue("@thisOrder", orderID);
        //    cmd.Parameters.AddWithValue("@orderItem", item);
        //    cmd.Parameters.AddWithValue("@storeRef", store);
        //    cmd.ExecuteNonQuery();

        //    connection.Close();
        //}

        //public void AddNewTransaction(string orderID, string buyer, string store, int ordertotal)
        //{
        //    using SqlConnection connection = new(_connectionString);
        //    connection.Open();

        //    // assume the order exist already in the DB
        //    string cmdText = @"INSERT INTO shop.OrderSummary (nameonOrder, ID, orderTotal, store)
        //                       VALUES (  @thisName, @thisOrder , @thisTotal, @storeRef)";
        //    using SqlCommand cmd = new(cmdText, connection);

        //    // ado.net requires you to use DBNull instead of null when you mean a SQL NULL value
        //    cmd.Parameters.AddWithValue("@thisName", buyer);
        //    cmd.Parameters.AddWithValue("@thisOrder", orderID);
        //    cmd.Parameters.AddWithValue("@thisTotal", ordertotal);
        //    cmd.Parameters.AddWithValue("@storeRef", store);
        //    cmd.ExecuteNonQuery();

        //    connection.Close();
        //}

        /* THIS WORKS DONT FK WITH IT */
        //public void AddNewUser(string user)
        //{
        //    using SqlConnection connection = new(_connectionString);
        //    connection.Open();
        //    string cmdText = @"INSERT INTO shop.Users (userName)
        //                            VALUES (@thisName)
        //                            ;";
        //    using SqlCommand cmd = new(cmdText, connection);

        //    // ado.net requires you to use DBNull instead of null when you mean a SQL NULL value
        //    cmd.Parameters.AddWithValue("@thisName", user);
        //    cmd.ExecuteNonQuery();
        //    connection.Close();
        //    Console.WriteLine($"{user} added to the records");
        //    GetAllTransactions(user);
        //    Console.WriteLine($"{user} records are loaded");
        //    Console.ReadLine();
        //}



        //public int getInventory(string item)
        //{
        //    using SqlConnection connection = new(_connectionString);
        //    connection.Open();

        //    string cmdText = @"SELECT Inventory
        //                       FROM shop.Items
        //                       WHERE itemName = @thisItem";
        //    using (SqlCommand cmd = new(cmdText, connection))
        //    {
        //        cmd.Parameters.AddWithValue("@thisItem", item);

        //        using SqlDataReader reader = cmd.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            return reader.GetInt32(0);
        //        }
        //        else
        //            Console.WriteLine("Failed to load inventory!");
        //        return 0;
        //    }
        //}





    }
}

