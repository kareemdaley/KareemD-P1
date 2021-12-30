using System;
namespace CreateAPI.App
{
	public class User
	{
		string Name { get; set; }
		string ID { get; set; }

		public User(string name, string id)
		{

			Name = name;
			ID = id;
            

		}
	}
}

