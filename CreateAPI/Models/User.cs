using System;
namespace CreateAPI.App
{
	public class User
	{

		public string Name { get; set; }
		public string ID { get; set; }

		public User(string name, string id)
		{

			Name = name;
			ID = id;
            

		}
	}
}

