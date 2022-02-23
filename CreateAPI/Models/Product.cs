using System;
namespace CreateAPI.App
{
	public class Product
	{
		public string Name { get; set; }
		public int Price { get; set; }
		public int Inventory { get; set; }
		public string Store { get; set; }

		public Product(string name , int price, int inventory, string store)
		{
			Name = name;
			Price = price;
			Inventory = inventory;
			Store = store;


        }
	}
}

