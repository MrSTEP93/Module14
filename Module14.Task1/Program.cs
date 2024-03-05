using System;
using System.Collections.Generic;
using System.Linq;

namespace Module14.Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян", "Ааскер", "Онатолий", "Аспиликуэта", "БАндроид", };

            var selectedPeople = from p in people // промежуточная переменная p 
                                 where p.StartsWith("А") || p.StartsWith("Б")                                 // фильтрация по условию
                                 orderby p // сортировка по возрастанию (дефолтная)
                                 select p; // выбираем объект и сохраняем в выборку

            //foreach (string s in selectedPeople)
            //    Console.WriteLine(s);

            //var nums = new List<int>() { 2, 9, 7, 55, 4, 7, 21, 1, 2 };
            //var orderedNums = nums.Where(n => n < 10).OrderBy(n => n);
            //foreach (var num in orderedNums)
            //    Console.WriteLine(num);

            var employees = new List<Employee>
            {
               new Employee {Name="Иван", Department="Продажи", Standing="Глава", Seniority=11 },
               new Employee {Name="Анна", Department="Продажи", Seniority=1 },
               new Employee {Name="Кирилл", Department="Разработка", Seniority=3 },
               new Employee {Name="Дмитрий", Department="Разработка", Seniority=5 },
               new Employee {Name="Олег", Department="Разработка", Standing="Глава", Seniority=8 }
            };

            var foreign = new List<Employee>
            {
                new Employee {Name="Zalfa Hachikovna", Department="CleaningManagers", Seniority=46},
                new Employee {Name="Radzh Indusovich", Department="Разработка", Seniority=10},
                new Employee {Name="Sara", Department="Секретарь", Seniority=10},
            };

            // группируем сотрудников по департаменту
            var groups = employees.Union(foreign).GroupBy(e => e.Department);
            Console.WriteLine("Our departments:");
            foreach (var group in groups)
            {
                Console.WriteLine(group.Key);
            }

            var progers = employees.Union(foreign).Where(x => x.Department == "Разработка").OrderByDescending(n => n.Standing).ThenByDescending(n => n.Seniority);
            Console.WriteLine("\nOur codeguys");
            foreach (var man in progers)
            {
                Console.WriteLine($"{man.Name}, {man.Standing}, стаж {man.Seniority}");
            }
            Console.WriteLine($"Средний стаж: { progers.Average(x => x.Seniority) }");
            Console.WriteLine($"Из них имеют стаж больше 3 лет: { progers.Count(x => x.Seniority > 5) }");

            var objects = new List<object>()
                {
                   1,
                   "Сергей ",
                   "Андрей ",
                   300,
                };
            var names = objects.Where(x => x is string);
            Console.WriteLine();
        }
    }
}
