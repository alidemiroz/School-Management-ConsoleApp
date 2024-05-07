using System;
using System.Collections.Generic;

namespace School_Management_ConsoleApp
{
	internal class Tools
	{
		public string ShiftFirstChar(string text)
		{
			char firstChar = char.ToUpper(text[0]);
			string otherChars = text.Substring(1).ToLower();
			return firstChar + otherChars;
		}

		public bool BirthDateControle(int year, int month, int day)
		{
            if (year < 1900 || year > DateTime.Now.Year)
                return false;
            if (month < 1 || month > 12)
                return false;
            if (day < 1 || day > DateTime.DaysInMonth(year, month))
                return false;
            if (month == 2 && day > 28)
            {
                if (!DateTime.IsLeapYear(year) || day > 29)
                    return false;
            }
            return true;
        }

        public bool StudentControle(List<Student> students, int no)
        {
            foreach (var item in students)
            {
                if (item.StudentNo == no)
                {
                    return true;
                }
            }
            return false;
        }

        public void ShowTittle()
        {
            Console.WriteLine();
            Console.WriteLine("Şube      No        Adı Soyadı               Not Ort.       Okudugu Kitap Say.");
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        public void ShowInfo(string entry)
        {
            Console.WriteLine();
            Console.WriteLine(entry);
            Console.WriteLine();
        }

        public int GetStudentNo()
        {
            Console.Write("Öğrencinin numarası:");
            int no = int.Parse(Console.ReadLine());
            return no;
        }

        public string GetText(string entry)
        {
            Console.Write(entry);
            string text = Console.ReadLine();
            return text;
        }

        public void ShowStudentInfo(Student student)
        {
            Console.WriteLine("Öğrencinin Adı Soyadı: " + student.Name + " " + student.LastName);
            Console.WriteLine("Öğrencinin Şubesi: " + student.Branch);
            Console.WriteLine();
        }
    }
}

