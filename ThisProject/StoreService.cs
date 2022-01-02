using System;
using System.Text.Json;
using ThisProject.Dtos;

namespace ThisProject
{
    public class StoreService
    {
        public static readonly HttpClient HttpClient = new();



        public static async Task<List<Product>> getProductsAsync(string name)
        {
            
            List<Product> productList = new List<Product>();


        HttpResponseMessage response3 = await HttpClient.GetAsync($"https://localhost:7078/api/Product?name={name}");
            string json3 = await response3.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<dtoProduct>>(json3);

            foreach (var Product in products)
            {
                //Console.WriteLine($"{Product.name} cost {Product.price} at {Product.store}.\nThere are {Product.inventory} left in stock");
                productList.Add(new Product(Product.name, Product.price, Product.inventory));
                
            }
            return productList;

        }

        public static async Task newUser(string name)
        {
            dtoUser user = new(name);
            HttpRequestMessage request = new(HttpMethod.Post, $"https://localhost:7078/api/User?name={name}");
            request.Content = new StringContent(JsonSerializer.Serialize(user));

            HttpResponseMessage response;
            try
            {
                response = await HttpClient.SendAsync(request);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("newtwork error", ex);
                    //UnexpectedServerBehaviorException("newtwork error", ex);
            }
            


            HttpResponseMessage response2 = await HttpClient.GetAsync($"https://localhost:7078/api/User?name={name}");
            string json2 = await response2.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<dtoUser>>(json2);

            foreach (var User in users)
            {
                Console.WriteLine($"User Id: {User.id} - {User.name} ");
            }

            await getOrdersAsync(name);

        }

        public static async Task getOrdersAsync(string name)
        {

            HttpResponseMessage response = await HttpClient.GetAsync($"https://localhost:7078/api/Order?name={name}");
            string json = await response.Content.ReadAsStringAsync();
            var orders = JsonSerializer.Deserialize<List<dtoOrder>>(json);

            foreach (var Order in orders)
            {
                Console.WriteLine($"Order id: {Order.orderID} - {Order.buyer} Total ${Order.item}");
            }

        }
    }
}

