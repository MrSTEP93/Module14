using System;
using System.Collections.Generic;
using System.Linq;

namespace Module14.Task2
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            //WorkWithCities();

            //WorkWithStudents();

            //WorkWithcompanies();

            var numsList = new List<int[]>()
            {
               new[] {2, 3, 7, 1},
               new[] {45, 17, 88, 0},
               new[] {23, 32, 44, -6},
            };

            var ints = numsList.SelectMany(n => n).OrderBy(n => n);
            foreach (var num in ints)
            {
                Console.WriteLine($"{num}");
            }
        }

        private static void WorkWithcompanies()
        {
            var companies = new Dictionary<string, string[]>();

            companies.Add("Apple", new[] { "Mobile", "Desktop" });
            companies.Add("Samsung", new[] { "Mobile" });
            companies.Add("IBM", new[] { "Desktop" });

            var mobileManufact = companies.Where(c => c.Value.Contains("Mobile"));
            Console.WriteLine(mobileManufact.Count());
        }

        private static void WorkWithStudents()
        {
            List<Student> students = new List<Student>
            {
               new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
               new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
               new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
               new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            // Составим запрос ()
            //var selectedStudents = students.SelectMany(
            //       // коллекция, которую нужно преобразовать
            //       s => s.Languages,
            //       // функция преобразования, применяющаяся к каждому элементу коллекции
            //       (s, l) => new { Student = s, Lang = l })
            //   // дополнительные условия                          
            //   .Where(s => s.Lang == "английский" && s.Student.Age < 28)
            //   // указатель на объект выборки
            //   .Select(s => s.Student);

            var selectedStudents = students.SelectMany(sl => sl.Languages, (s, l) => new { Student = s, Lang = l }).
                Where(sl => sl.Lang == "английский" && sl.Student.Age < 28).Select(s => s.Student);

            //var selectedStudents = students.Where(s => (s.Age < 28) && s.Languages)

            // Выведем результат
            foreach (Student student in selectedStudents)
                Console.WriteLine($"{student.Name} - {student.Age}");
        }

        private static void WorkWithCities()
        {
            var Countries = new Dictionary<string, List<City>>();

            // Добавим Россию с её городами
            var russianCities = new List<City>();
            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Севастополь", 449138));
            russianCities.Add(new City("Новороссийск", 1150000));
            Countries.Add("Россия", russianCities);

            // Добавим Беларусь
            var belarusCities = new List<City>();
            belarusCities.Add(new City("Минск", 1200000));
            belarusCities.Add(new City("Витебск", 362466));
            belarusCities.Add(new City("Гродно", 368710));
            Countries.Add("Беларусь", belarusCities);

            // Добавим США
            var americanCities = new List<City>();
            americanCities.Add(new City("Нью-Йорк", 8399000));
            americanCities.Add(new City("Вашингтон", 705749));
            americanCities.Add(new City("Альбукерке", 560218));
            Countries.Add("США", americanCities);

            var values = from country in Countries
                         from city in country.Value
                         where city.Population > 1000000
                         orderby city.Population descending
                         select new { Country = country.Key, City = city };

            foreach (var cityInfo in values)
                Console.WriteLine($"{cityInfo.Country}, {cityInfo.City.Name} - {cityInfo.City.Population}");

            var bigCities = from country in Countries
                            from city in country.Value
                            where city.Population > 1000000
                            orderby city.Population descending
                            select city;


            var longCities = russianCities.Where(c => c.Name.Length < 10).OrderBy(c => c.Name.Length);
            //            PrintEnum(bigCities);
        }

        private static void PrintEnum(IEnumerable<City> cities)
        {
            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Name} with population {city.Population:N0}");
            }
        }
    }

    public class Student
    {
        public string Name;
        public byte Age;
        public List<string> Languages;


        public Student() { }

        public Student(string name, byte age, List<string> langs) 
        {
            Name = name;
            Age = age;
            Languages = langs;
        }
    }
}
