using System;
using System.Collections.Generic;
using System.Linq;

namespace School_Management_ConsoleApp
{
	internal class School
	{
        List<Student> Students = new List<Student>();
        public Program program = new Program();
        public Student student = new Student();
        public Tools tools = new Tools();

        public void ListingAllStudents()
        {
            Console.WriteLine("1-Bütün Öğrencileri Listele --------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Şube      No        Adı Soyadı               Not Ort.Okudugu Kitap Say.");
            Console.WriteLine("---------------------------------------------------------------------------");
            foreach (Student item in Students)
            {
                Console.WriteLine(item.Branch.ToString().PadRight(10) + item.StudentNo.ToString().PadRight(10) + (item.Name + " " + item.LastName).PadRight(25) + item.NoteAverage.ToString().PadRight(15) + item.Books.Count);
            }
            program.BackToMenu();
        }

        public void ListingForBranch()
        {
            Console.WriteLine("2-Şubeye Göre Öğrencileri Listele --------------------------------------------");
            while (true)
            {
                try
                {
                    Console.Write("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                    string branchStr = Console.ReadLine().ToUpper();
                    Branch branch;

                    if (Enum.TryParse(branchStr, out branch))
                    {
                        var forBranch = Students.Where(stu => stu.Branch == branch).OrderBy(stu => stu.Name).ToList();
                        tools.ShowTittle();
                        foreach (var item in forBranch)
                        {
                            Console.WriteLine(item.Branch.ToString().PadRight(10) + item.StudentNo.ToString().PadRight(10) + (item.Name + " " + item.LastName).PadRight(25) + item.NoteAverage.ToString().PadRight(15) + item.Books.Count);
                        }
                    }
                    else
                    {
                        tools.ShowInfo("Geçersiz ifade girildi. Lütfen A/B/C ifadelerinden birini giriniz.");
                    }
                }
                catch
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void ListingForSexual()
        {
            Console.WriteLine("3-Cinsiyete Göre Öğrencileri Listele --------------------------------------------");
            while (true)
            {
                try
                {
                    Console.Write("Listelemek istediğiniz cinsiyeti girin (Kiz/Erkek): ");
                    string genderStr = tools.ShiftFirstChar(Console.ReadLine());
                    Gender gender;

                    if (Enum.TryParse(genderStr, out gender))
                    {
                        var forGender = Students.Where(stu => stu.Gender == gender).OrderBy(stu => stu.Name).ToList();
                        Console.WriteLine();
                        Console.WriteLine("Cinsiyet      No        Adı Soyadı               Not Ort.       Okudugu Kitap Say.");
                        Console.WriteLine("-------------------------------------------------------------------------------");
                        foreach (var item in forGender)
                        {
                            Console.WriteLine(item.Gender.ToString().PadRight(13) + item.StudentNo.ToString().PadRight(13) + (item.Name + " " + item.LastName).PadRight(28) + item.NoteAverage.ToString().PadRight(18) + item.Books.Count);
                        }
                        program.BackToMenu();
                    }
                    else
                    {
                        tools.ShowInfo("Geçersiz cinsiyet girildi. Lütfen Kiz/Erkek ifadelerinden birini giriniz.");
                    }
                }
                catch
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void ListingForBirthDate()
        {
            Console.WriteLine("4-Dogum Tarihine Göre Ögrencileri Listele ------------------------------------");
            while (true)
            {
                try
                {
                    Console.Write("Hangi tarihten sonraki ögrencileri listelemek istersiniz (GG.AA.YYYY): ");
                    string dateStr = Console.ReadLine();
                    if (DateTime.TryParseExact(dateStr, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime birthDate))
                    {
                        var forBirthdate = Students.Where(stu => stu.BirthDate > birthDate).OrderBy(stu => stu.Name).ToList();
                        tools.ShowTittle();
                        foreach (var item in forBirthdate)
                        {
                            Console.WriteLine(item.Branch.ToString().PadRight(10) + item.StudentNo.ToString().PadRight(10) + (item.Name + " " + item.LastName).PadRight(25) + item.NoteAverage.ToString().PadRight(15) + item.Books.Count);
                        }
                        program.BackToMenu();
                    }
                    else
                    {
                        tools.ShowInfo("Geçersiz doğum tarihi. Lütfen tekrar girin.");
                    }
                }
                catch
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void ListingForCities()
        {
            Console.WriteLine("5-Illere Göre Ögrencileri Listele --------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sube      No        Adı Soyadı           Sehir          İlçe");
            Console.WriteLine("-------------------------------------------------------------------------------");
            var forCities = Students.OrderBy(stu => stu.Adress.City).ToList();
            foreach (var item in forCities)
            {
                Console.WriteLine(item.Branch.ToString().PadRight(10) + item.StudentNo.ToString().PadRight(10) + (item.Name + " " + item.LastName).PadRight(25) + item.Adress.City.PadRight(15) + item.Adress.District);
            }
            program.BackToMenu();
        }

        public void ListingStudentNote()
        {
            Console.WriteLine("6-Ögrencinin notlarını görüntüle ---------------------------------------------");
            while (true)
            {
                try
                {
                    int no = tools.GetStudentNo();
                    Student student = Students.Find(o => o.StudentNo == no);
                    if (student == null)
                    {
                        tools.ShowInfo("Bu numarada bir öğrenci bulunamadı.");
                        continue;
                    }
                    tools.ShowStudentInfo(student);
                    Console.WriteLine("Dersin Adi     Notu");
                    Console.WriteLine("--------------------");
                    foreach (var item in student.Notes)
                    {
                        Console.WriteLine((item.Name).PadRight(15) + (item.Point));
                    }
                    program.BackToMenu();
                }
                catch
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void ListingStudentsBook()
        {
            Console.WriteLine("7-Ögrencinin okudugu kitapları listele ---------------------------------------");
            while (true)
            {
                try
                {
                    int numara = tools.GetStudentNo();
                    Student student = Students.Find(o => o.StudentNo == numara);
                    if (student == null)
                    {
                        tools.ShowInfo("Bu numarada bir öğrenci bulunamadı.");
                        continue;
                    }
                    tools.ShowStudentInfo(student);
                    Console.WriteLine("Okudugu Kitaplar");
                    Console.WriteLine("-----------------");
                    foreach (var item in student.Books)
                    {
                        Console.WriteLine("-" + item);
                    }
                    program.BackToMenu();
                }
                catch
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void ListingHighestNote()
        {
            Console.WriteLine("8-Okuldaki en basarılı 5 ögrenciyi listele -----------------------------------");
            var highNotes = Students.OrderByDescending(stu => stu.NoteAverage).Take(5).ToList();
            tools.ShowTittle();
            foreach (var item in highNotes)
            {
                Console.WriteLine(item.Branch.ToString().PadRight(10) + item.StudentNo.ToString().PadRight(10) + (item.Name + " " + item.LastName).PadRight(25) + item.NoteAverage.ToString().PadRight(15) + item.Books.Count);
            }
            program.BackToMenu();
        }

        public void ListingLowestNote()
        {
            Console.WriteLine("9-Okuldaki en basarısız 3 ögrenciyi listele -----------------------------------");
            var lowestNotes = Students.OrderBy(stu => stu.NoteAverage).Take(3).ToList();
            tools.ShowTittle();
            foreach (var item in lowestNotes)
            {
                Console.WriteLine(item.Branch.ToString().PadRight(10) + item.StudentNo.ToString().PadRight(10) + (item.Name + " " + item.LastName).PadRight(25) + item.NoteAverage.ToString().PadRight(15) + item.Books.Count);
            }
            program.BackToMenu();
        }

        public void ListingHighestNoteBranch()
        {
            Console.WriteLine("10-Subedeki en basarılı 5 ögrenciyi listele -----------------------------------");
            while (true)
            {
                try
                {
                    Console.Write("Bir şube seçin (A/B/C): ");
                    string branchStr = Console.ReadLine().ToUpper();
                    Branch branch;
                    if (Enum.TryParse(branchStr, out branch))
                    {
                        List<Student> forBranch = Students.Where(stu => stu.Branch == branch).ToList();
                        var highestNotes = forBranch.OrderByDescending(stu => stu.NoteAverage).Take(5).ToList();
                        tools.ShowTittle();
                        foreach (var item in highestNotes)
                        {
                            Console.WriteLine(item.Branch.ToString().PadRight(10) + item.StudentNo.ToString().PadRight(10) + (item.Name + " " + item.LastName).PadRight(25) + item.NoteAverage.ToString().PadRight(15) + item.Books.Count);
                        }
                        program.BackToMenu();
                    }
                    else
                    {
                        tools.ShowInfo("Geçersiz şube girişi. Lütfen A, B veya C seçeneklerinden birini girin.");
                    }
                }
                catch
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void ListingLowestNoteBranch()
        {
            Console.WriteLine("11-Subedeki en basarısız 3 ögrenciyi listele -----------------------------------");
            while (true)
            {
                try
                {
                    Console.Write("Bir şube seçin (A/B/C): ");
                    string branchStr = Console.ReadLine().ToUpper();
                    Branch branch;
                    if (Enum.TryParse(branchStr, out branch))
                    {
                        List<Student> forBranch = Students.Where(stu => stu.Branch == branch).ToList();
                        var lowestNotes = forBranch.OrderBy(stu => stu.NoteAverage).Take(3).ToList();
                        tools.ShowTittle();
                        foreach (var item in lowestNotes)
                        {
                            Console.WriteLine(item.Branch.ToString().PadRight(10) + item.StudentNo.ToString().PadRight(10) + (item.Name + " " + item.LastName).PadRight(25) + item.NoteAverage.ToString().PadRight(15) + item.Books.Count);
                        }
                        program.BackToMenu();
                    }
                    else
                    {
                        tools.ShowInfo("Geçersiz şube girişi. Lütfen A, B veya C seçeneklerinden birini girin.");
                    }
                }
                catch
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void ShowingStudentNoteAverage()
        {
            Console.WriteLine("12-Ögrencinin Not Ortalamasını Gör -----------------------------------");
            while (true)
            {
                try
                {
                    int no = tools.GetStudentNo();
                    Student student = Students.Find(o => o.StudentNo == no);
                    if (student == null)
                    {
                        tools.ShowInfo("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                        continue;
                    }
                    tools.ShowStudentInfo(student);
                    Console.WriteLine("Öğrencinin not ortalaması: " + student.NoteAverage);
                    program.BackToMenu();
                }
                catch
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void ShowingBranchNoteAverage()
        {
            Console.WriteLine("13-Şubenin Not Ortalamasını Gör -------------------------------------");
            while (true)
            {
                try
                {
                    Console.Write("Bir şube seçin (A/B/C): ");
                    string branchStr = Console.ReadLine().ToUpper();
                    Branch branch;
                    if (Enum.TryParse(branchStr, out branch))
                    {
                        List<Student> forBranch = Students.Where(stu => stu.Branch == branch).ToList();
                        float totalAverage = 0;
                        foreach (var item in forBranch)
                        {
                            totalAverage += item.NoteAverage;
                        }
                        float branchNoteAverage = forBranch.Count > 0 ? totalAverage / forBranch.Count : 0;
                        Console.WriteLine();
                        Console.WriteLine(branch + " şubesinin not ortalaması: " + branchNoteAverage);
                        program.BackToMenu();
                    }
                    else
                    {
                        tools.ShowInfo("Geçersiz şube girişi. Lütfen A, B veya C seçeneklerinden birini girin.");
                    }
                }
                catch
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void ShowStudentsLastBook()
        {
            Console.WriteLine("14-Ögrencinin okudugu son kitabı listele ----------------------------");
            while (true)
            {
                try
                {
                    int no = tools.GetStudentNo();
                    Student student = Students.Find(o => o.StudentNo == no);
                    if (student == null)
                    {
                        tools.ShowInfo("Bu numarada bir öğrenci bulunamadı.");
                    }
                    tools.ShowStudentInfo(student);
                    Console.WriteLine("Ögrencinin Okudugu Son Kitap");
                    Console.WriteLine("------------------------------");
                    if (student.Books.Count == 0)
                    {
                        Console.WriteLine("Hiç kitap okumamış.");
                        program.BackToMenu();
                    }
                    Console.WriteLine("Öğrencinin okuduğu son kitap: " + student.Books[student.Books.Count - 1]);
                    program.BackToMenu();
                }
                catch
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void AddStudent()
        {
            Student student = new Student();
            Console.WriteLine("15-Öğrenci Ekle ------------------------------------------------------");
            while (true)
            {
                try
                {
                    while (true)
                    {
                        int no = tools.GetStudentNo();
                        if (tools.StudentControle(Students, no))
                        {
                            tools.ShowInfo("Bu numarada bir öğrenci zaten var. Lütfen farklı bir numara girin.");
                            continue;
                        }
                        student.StudentNo = no;
                        break;
                    }
                    Console.Write("Adı: ");
                    student.Name = tools.ShiftFirstChar(Console.ReadLine());
                    Console.Write("Soyadı: ");
                    student.LastName = tools.ShiftFirstChar(Console.ReadLine());
                    while (true)
                    {
                        Console.Write("Doğum Yılı: ");
                        int year = int.Parse(Console.ReadLine());
                        Console.Write("Doğum Ayı: ");
                        int month = int.Parse(Console.ReadLine());
                        Console.Write("Doğum Günü: ");
                        int day = int.Parse(Console.ReadLine());
                        if (tools.BirthDateControle(year, month, day))
                        {
                            student.BirthDate = new DateTime(year, month, day);
                            break;
                        }
                        else
                        {
                            tools.ShowInfo("Geçersiz doğum tarihi. Lütfen tekrar girin.");
                        }
                    }
                    while (true)
                    {
                        Console.Write("Cinsiyet (Erkek/Kız): ");
                        string genderStr = tools.ShiftFirstChar(Console.ReadLine());
                        Gender gender;
                        if (Enum.TryParse(genderStr, out gender))
                        {
                            student.Gender = gender;
                            break;
                        }
                        else
                        {
                            tools.ShowInfo("Geçersiz cinsiyet girişi. Lütfen Erkek veya Kiz seçeneklerinden birini girin.");
                        }
                    }
                    while (true)
                    {
                        Console.Write("Şube (A/B/C): ");
                        string branchStr = Console.ReadLine().ToUpper();
                        Branch branch;
                        if (Enum.TryParse(branchStr, out branch))
                        {
                            student.Branch = branch;
                            break;
                        }
                        else
                        {
                            tools.ShowInfo("Geçersiz şube girişi. Lütfen A, B veya C seçeneklerinden birini girin.");
                        }
                    }
                    this.Students.Add(student);
                    Console.WriteLine();
                    Console.WriteLine(student.StudentNo + ". Numaralı öğrenci sisteme başarıyla eklendi.");
                    program.BackToMenu();
                }
                catch 
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void UpdateStudent()
        {
            Console.WriteLine("16-Ögrenci Güncelle -----------------------------------------------------------");
            while (true)
            {
                try
                {
                    int no = tools.GetStudentNo();
                    Student student = Students.Find(o => o.StudentNo == no);
                    if (student == null)
                    {
                        tools.ShowInfo("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                        continue;
                    }
                    Console.Write("Adı: ");
                    student.Name = tools.ShiftFirstChar(Console.ReadLine());
                    Console.Write("Soyadı: ");
                    student.LastName = tools.ShiftFirstChar(Console.ReadLine());
                    while (true)
                    {
                        Console.Write("Doğum Yılı: ");
                        int year = int.Parse(Console.ReadLine());
                        Console.Write("Doğum Ayı: ");
                        int month = int.Parse(Console.ReadLine());
                        Console.Write("Doğum Günü: ");
                        int day = int.Parse(Console.ReadLine());
                        if (tools.BirthDateControle(year, month, day))
                        {
                            student.BirthDate = new DateTime(year, month, day);
                            break;
                        }
                        else
                        {
                            tools.ShowInfo("Geçersiz doğum tarihi. Lütfen tekrar girin.");
                        }
                    }
                    while (true)
                    {
                        Console.Write("Cinsiyet (Erkek/Kız): ");
                        string genderStr = tools.ShiftFirstChar(Console.ReadLine());
                        Gender gender;
                        if (Enum.TryParse(genderStr, out gender))
                        {
                            student.Gender = gender;
                            break;
                        }
                        else
                        {
                            tools.ShowInfo("Geçersiz cinsiyet girişi. Lütfen Erkek veya Kiz seçeneklerinden birini girin.");
                        }
                    }
                    while (true)
                    {
                        Console.Write("Şube (A/B/C): ");
                        string branchStr = Console.ReadLine().ToUpper();
                        Branch branch;
                        if (Enum.TryParse(branchStr, out branch))
                        {
                            student.Branch = branch;
                            break;
                        }
                        else
                        {
                            tools.ShowInfo("Geçersiz şube girişi. Lütfen A, B veya C seçeneklerinden birini girin.");
                        }
                    }
                    tools.ShowInfo("Öğrenci Güncellendi.");
                    program.BackToMenu();
                }
                catch 
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void DeleteStudent()
        {
            Console.WriteLine("17-Ögrenci sil ----------------------------------------------------------------");
            while (true)
            {
                try
                {
                    int no = tools.GetStudentNo();
                    Student student = Students.Find(o => o.StudentNo == no);
                    if (student == null)
                    {
                        tools.ShowInfo("Bu numarada bir öğrenci bulunamadı.");
                        continue;
                    }
                    tools.ShowStudentInfo(student);
                    while (true)
                    {
                        Console.Write("Öğrenciyi silmek istediğinize emin misiniz? (E/H): ");
                        string answer = Console.ReadLine().ToUpper();
                        if (answer == "E")
                        {
                            Students.Remove(student);
                            tools.ShowInfo("Öğrenci silindi.");
                            program.BackToMenu();
                        }
                        else if (answer == "H")
                        {
                            tools.ShowInfo("Öğrenci silinmedi.");
                            program.BackToMenu();
                        }
                        else
                        {
                            tools.ShowInfo("Geçersiz giriş yapıldı. Lütfen E/H girişi yapınız.");
                        }
                    }
                }
                catch 
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void EntryStudentAdress()
        {
            Console.WriteLine("18 - Ögrencinin Adresini Gir ------------------------------------------");
            while (true)
            {
                try
                {
                    int no = tools.GetStudentNo();
                    Student student = Students.Find(o => o.StudentNo == no);
                    if (student == null)
                    {
                        tools.ShowInfo("Bu numarada bir öğrenci bulunamadı.");
                        continue;
                    }
                    tools.ShowStudentInfo(student);
                    Console.Write("İl: ");
                    string city = tools.ShiftFirstChar(Console.ReadLine());
                    Console.Write("İlçe: ");
                    string district = tools.ShiftFirstChar(Console.ReadLine());
                    student.Adress = new Adress(city, district);
                    tools.ShowInfo("Bilgiler sisteme girilmiştir.");
                    program.BackToMenu();
                }
                catch 
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void EntryStudentLastBook()
        {
            Console.WriteLine("19-Ögrencinin okudugu kitabı gir ------------------------------------");
            while (true)
            {
                try
                {
                    int no = tools.GetStudentNo();
                    Student student = Students.Find(o => o.StudentNo == no);
                    if (student == null)
                    {
                        tools.ShowInfo("Bu numarada bir öğrenci bulunamadı.");
                        continue;
                    }
                    tools.ShowStudentInfo(student);
                    Console.Write("Eklenecek kitabın adı:");
                    string book = tools.ShiftFirstChar(Console.ReadLine());
                    student.Books.Add(book);
                    tools.ShowInfo("Bilgiler sisteme girilmiştir.");
                    program.BackToMenu();
                }
                catch 
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void EntryStudentNote()
        {
            Console.WriteLine("20-Not Gir -----------------------------------------------------------");
            while (true)
            {
                try
                {
                    int no = tools.GetStudentNo();
                    Student student = Students.Find(o => o.StudentNo == no);
                    if (student == null)
                    {
                        tools.ShowInfo("Bu numarada bir öğrenci bulunamadı.");
                        continue;
                    }
                    tools.ShowStudentInfo(student);
                    Console.Write("Not eklemek istediğiniz ders(Matematik,Türkçe,Sosyal,Fen): ");
                    string lesson = tools.ShiftFirstChar(Console.ReadLine());
                    Console.Write("Eklemek istediğiniz not adedi: ");
                    int piece = int.Parse(Console.ReadLine());
                    for (int i = 0; i < piece; i++)
                    {
                        Console.Write((i + 1) + ". Not: ");
                        int note = int.Parse(Console.ReadLine());
                        student.Notes.Add(new Note(lesson, note));
                    }
                    tools.ShowInfo("Bilgiler sisteme girilmiştir.");
                    program.BackToMenu();
                }
                catch 
                {
                    tools.ShowInfo("Girdiğiniz değer program tarafından istenen değere dönüştürülemedi.");
                }
            }
        }

        public void CreateFakeStudent()
        {
            student.AddStudentAssistant(Students, 1, "Ali", "Yılmaz", new DateTime(2000, 5, 4), new Adress("Ankara", "Çankaya"), Branch.A, Gender.Erkek, "Suç ve Ceza", new Note("Matematik", 80));
            student.AddStudentAssistant(Students, 2, "Elif", "Selçuk", new DateTime(2001, 11, 25), new Adress("Bursa", "Nilüfer"), Branch.C, Gender.Kiz, "Sefiller", new Note("Matematik", 66));
            student.AddStudentAssistant(Students, 3, "Betül", "Yılmaz", new DateTime(2000, 3, 17), new Adress("Bursa", "Yıldırım"), Branch.B, Gender.Kiz, "Anna Karenina", new Note("Türkçe", 87));
            student.AddStudentAssistant(Students, 4, "Hakan", "Çelik", new DateTime(1999, 8, 2), new Adress("Çanakkale", "Bozcaada"), Branch.A, Gender.Erkek, "Vadideki Zambak", new Note("Türkçe", 56));
            student.AddStudentAssistant(Students, 5, "Kerem", "Akay", new DateTime(2000, 12, 27), new Adress("İstanbul", "Beşiktaş"), Branch.B, Gender.Erkek, "Notre Dame'ın Kamburu", new Note("Sosyal", 72));
            student.AddStudentAssistant(Students, 6, "Hatice", "Çınar", new DateTime(1998, 5, 30), new Adress("İstanbul", "Kadıköy"), Branch.C, Gender.Kiz, "Aşk ve Gurur", new Note("Sosyal", 81));
            student.AddStudentAssistant(Students, 7, "Selim", "İleri", new DateTime(1999, 6, 7), new Adress("İzmir", "Bornova"), Branch.B, Gender.Erkek, "İlahi Komedya", new Note("Fen", 69));
            student.AddStudentAssistant(Students, 8, "Selda", "Kavak", new DateTime(2002, 12, 16), new Adress("İzmir", "Çeşme"), Branch.A, Gender.Kiz, "Romeo ve Juliet", new Note("Fen", 94));
            student.AddStudentAssistant(Students, 9, "Pınar", "Kebir", new DateTime(2000, 4, 11), new Adress("Antalya", "Belek"), Branch.A, Gender.Kiz, "Savaş ve Barış", new Note("Matematik", 99));
        }
    }
}

