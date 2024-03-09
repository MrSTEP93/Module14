using System;
using System.Collections.Generic;
using System.Linq;

namespace Module14.Final1
{
   class Program
    {

        static List<Contact> phoneBook;
        static byte recordsOnPage = 2;

        static void Main(string[] args)
        {
            InitAddresBook();

            while (true)
            {
                Console.WriteLine("Enter the number of page: ");
                if (Byte.TryParse(Console.ReadLine(), out byte pageNum))
                {
                    //byte lastPageNum = (byte)((phoneBook.Count / recordsOnPage) + 1);
                    if (pageNum > 0 && pageNum <= (phoneBook.Count / recordsOnPage) + 1)
                    {
                        var sortedPhoneBook = phoneBook.OrderBy(x => x.Name).ThenBy(x => x.LastName);
                        var page = sortedPhoneBook.Skip((pageNum - 1) * recordsOnPage).Take(recordsOnPage);

                        foreach (var contact in page)
                            Console.WriteLine($"{contact.Name} {contact.LastName} :: {contact.PhoneNumber}");
                        }
                    else
                        Console.WriteLine("There is no records on this page");
                }
                else
                    Console.WriteLine("Incorrect number!");
            }
        }

        private static void InitAddresBook()
        {
            phoneBook = new List<Contact>
            {
                new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
                new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
                new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
                new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
                new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
                new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"),
                new Contact("Игорь", "Суханов", 799900001128, "sooxanov@example.com"),
                new Contact("Сергей", "Скоков", 799900000774, "skok1819@example.com"),
                new Contact("Марина", "Карцева", 799900000452, "m.karrzz@example.com"),
                
            };
        }
    }

    public class Contact
    {
        public Contact(string name, string lastName, long phoneNumber, String email)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}