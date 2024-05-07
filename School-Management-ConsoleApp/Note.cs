using System;
namespace School_Management_ConsoleApp
{
	internal class Note
	{
		public string Name { get; set; }
		public int Point { get; set; }
        public Note(string name, int point)
        {
            this.Name = name;
            this.Point = point;
        }


    }
}

