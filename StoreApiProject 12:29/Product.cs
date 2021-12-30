using System;
namespace CreateAPI.App
{
	public class Product
	{
		string Name { get; set; }
		string Price { get; set; }
		string Inventory { get; set; }
		string Store { get; set; }

		public Product(string name , string price, string inventory, string store)
		{
			Name = name;
			Price = price;
			Inventory = inventory;
			Store = store;


        }
	}
}

