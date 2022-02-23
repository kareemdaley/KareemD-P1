using System;
namespace ThisProject.Dtos
{
	public class dtoUser
	{
		public string name { get; set; }
		public string id { get; set; }

        public dtoUser(string name)
        {
            this.name = name;
        }
    }
}

