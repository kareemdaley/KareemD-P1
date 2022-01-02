using System;

namespace ThisProject
{
	public class Store
	{
        public string StoreName { get; set; }
        public List<Product> Products = new List<Product>();
        static string orderID;

        public Store(string storeName)
        {
            StoreName = storeName;
        }

        public async Task getProductsAsync()
        {
            Products = await StoreService.getProductsAsync(StoreName);
            foreach (var Product in Products)
            {
                //Console.WriteLine($"{Product.Title} cost {Product.Price} .\nThere are {Product.numLeft} left in stock");
            }
        }

        public void menu()
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("                Menu                 ");
            Console.WriteLine("Product       Price        Quantity");
            Console.WriteLine($"{Products[0].Title}           $5              {Products[0].numLeft}");
            Console.WriteLine($"{Products[1].Title}           $10             {Products[1].numLeft}");
            Console.WriteLine($"{Products[2].Title}           $15             {Products[2].numLeft}");
            Console.WriteLine("======================================");
        }




    }
}

