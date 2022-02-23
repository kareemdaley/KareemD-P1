using System;
namespace ThisProject
{
    public class Product
	{
		public string Title { get; set; }
		public int Price { get; set; }
		public int numLeft { get; set; }

		public Product(string title, int price, int quantity)
		{
			this.Title = title;
			this.Price = price;
			this.numLeft = quantity;
		}
	}
}

