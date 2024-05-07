using System;

namespace School_Management_ConsoleApp
{
    internal class Program
    {
        static School school = new School();
        static Tools tools = new Tools();
        static void Main(string[] args)
        {
            RunApp();
        }

        static void RunApp()
        {
            school.CreateFakeStudent();
            ShowMenu();
            MenuProcess();
        }

        static void ShowMenu()
        {
            Console.WriteLine("------Okul Yönetim Uygulamasi  -----");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("1 - Bütün öğrencileri listele");
            Console.WriteLine("2 - Şubeye göre öğrencileri listele");
            Console.WriteLine("3 - Cinsiyetine göre öğrencileri listele");
            Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine("5 - İllere göre sıralayarak öğrencileri listele");
            Console.WriteLine("6 - Öğrencinin tüm notlarını listele");
            Console.WriteLine("7 - Öğrencinin okuduğu kitapları listele");
            Console.WriteLine("8 - Okuldaki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("9 - Okuldaki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("10 - Şubedeki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("11 - Şubedeki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("12 - Öğrencinin not ortalamasını gör");
            Console.WriteLine("13 - Şubenin not ortalamasını gör");
            Console.WriteLine("14 - Öğrencinin okuduğu son kitabı gör");
            Console.WriteLine("15 - Öğrenci ekle");
            Console.WriteLine("16 - Öğrenci güncelle");
            Console.WriteLine("17 - Öğrenci sil");
            Console.WriteLine("18 - Öğrencinin adresini gir");
            Console.WriteLine("19 - Öğrencinin okuduğu kitabı gir");
            Console.WriteLine("20 - Öğrencinin notunu gir");
            Console.WriteLine();
            Console.WriteLine("Çıkış yapmak için “çıkış” yazıp “enter”a basın.");
            Console.WriteLine();
        }

        static void MenuProcess()
        {
            School school = new School();
            while (true)
            {
                try
                {
                    Console.Write("Yapmak istediğiniz işlemi seçiniz: ");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1": school.ListingAllStudents(); break;
                        case "2": school.ListingForBranch(); break;
                        case "3": school.ListingForSexual(); break;
                        case "4": school.ListingForBirthDate(); break;
                        case "5": school.ListingForCities(); break;
                        case "6": school.ListingStudentNote(); break;
                        case "7": school.ListingStudentsBook(); break;
                        case "8": school.ListingHighestNote(); break;
                        case "9": school.ListingLowestNote(); break;
                        case "10": school.ListingHighestNoteBranch(); break;
                        case "11": school.ListingLowestNoteBranch(); break;
                        case "12": school.ShowingStudentNoteAverage(); break;
                        case "13": school.ShowingBranchNoteAverage(); break;
                        case "14": school.ShowStudentsLastBook(); break;
                        case "15": school.AddStudent(); break;
                        case "16": school.UpdateStudent(); break;
                        case "17": school.DeleteStudent(); break;
                        case "18": school.EntryStudentAdress(); break;
                        case "19": school.EntryStudentLastBook(); break;
                        case "20": school.EntryStudentNote(); break;
                        default:
                            Console.WriteLine("");
                            Console.WriteLine("Geçersiz bir seçim yaptınız lütfen tekrar deneyin.");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("");
                    Console.WriteLine("Geçersiz bir seçim yaptınız lütfen tekrar deneyin.");
                }
            }
        }

        public void BackToMenu()
        {
            int count = 0;
            while (true)
            {
                if (count == 10)
                {
                    tools.ShowInfo("Üzgünüm sizi anlayamıyorum, program sonlandırılıyor.");
                    Environment.Exit(0);
                }
                tools.ShowInfo("Menüyü tekrar listelemek için 'Liste', çıkıs yapmak için 'Cikis' yazın.");
                string choice = tools.GetText("Yapmak istediğiniz işlemi seçiniz: ").ToLower();
                switch (choice)
                {
                    case "liste":
                        Console.WriteLine();
                        ShowMenu();
                        MenuProcess(); break;
                    case "cikis": Environment.Exit(0); break;
                    default:
                        count++;
                        tools.ShowInfo("Lütfen iki seçenekten birini giriniz."); break;
                }
            }
        }
    }
}

