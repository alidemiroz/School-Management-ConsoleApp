using System;
using System.Collections.Generic;

namespace School_Management_ConsoleApp
{
	internal class Student
	{
		public string Name { get; set; }
		public string LastName { get; set; }
		public int StudentNo { get; set; }
		public DateTime BirthDate { get; set; }
        public Branch Branch { get; set; }
        public Gender Gender { get; set; }
        public Adress Adress { get; set; }
		public List<Note> Notes = new List<Note>();
		public List<string> Books = new List<string>();
		public float NoteAverage
		{
			get
			{
				int totalNote = 0;
				foreach (var item in Notes)
				{
					totalNote += item.Point;
				}
				return (float)totalNote / (float)Notes.Count;
			}
		}

		public void AddStudentAssistant(List<Student> students, int no, string name, string lastname, DateTime birthdate, Adress adress, Branch branch, Gender gender, string book, Note note)
		{
			Student stu = new Student();
            stu.StudentNo = no;
            stu.Name = name;
            stu.LastName = lastname;
            stu.BirthDate = birthdate;
            stu.Adress = adress;
            stu.Branch = branch;
            stu.Gender = gender;
            stu.Books.Add(book);
            stu.Notes.Add(note);
            students.Add(stu);
        }
	}

	public enum Branch
	{
		Empty,A,B,C
	}

	public enum Gender
	{
		Empty,Kiz,Erkek
	}
}

