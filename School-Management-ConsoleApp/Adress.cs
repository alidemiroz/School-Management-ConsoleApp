using System;
namespace School_Management_ConsoleApp
{
	internal class Adress
	{
		public string City { get; set; }
		public string District { get; set; }
        public Adress(string city, string district)
        {
            this.City = city;
            this.District = district;
        }

    }
}

