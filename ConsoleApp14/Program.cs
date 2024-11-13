using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

public class Program
{
    //С помощью операторв LINQ
    public static void Main()
    {
        List<Person> persons = new List<Person>()
        {
            new Person(){ Name = "Andrey", Age = 24, City = "Kyiv"},
            new Person(){ Name = "Liza", Age = 18, City = "Odesa" },
            new Person(){ Name = "Oleg", Age = 15, City = "London" },
            new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
            new Person(){ Name = "Sergey", Age = 32, City = "Lviv" }
        };

        var older = (from p in persons
                           where p.Age > 25
                           select p).ToList();

        var notInLondon = (from p in persons
                           where p.City != "London"
                           select p).ToList();

        var InKyiv = (from p in persons
                           where p.City == "Kyiv"
                           select p.Name).ToList();

        var Older35Sergeys = (from p in persons
                                  where p.Age > 35 && p.Name == "Sergey"
                                  select p).ToList();

        var inOdesa = (from p in persons
                       where p.City == "Odesa"
                       select p).ToList();

       
        Console.WriteLine("Люди старше 25 лет:");
        older.ForEach(p => Console.WriteLine($"{p.Name}, {p.Age}, {p.City}"));

        Console.WriteLine("\nЛюди, проживающие не в Лондоне:");
        notInLondon.ForEach(p => Console.WriteLine($"{p.Name}, {p.Age}, {p.City}"));

        Console.WriteLine("\nИмена людей, проживающих в Киеве:");
        InKyiv.ForEach(name => Console.WriteLine(name));

        Console.WriteLine("\nЛюди с именем Sergey, старше 35 лет:");
        Older35Sergeys.ForEach(p => Console.WriteLine($"{p.Name}, {p.Age}, {p.City}"));

        Console.WriteLine("\nЛюди, проживающие в Одессе:");
        inOdesa.ForEach(p => Console.WriteLine($"{p.Name}, {p.Age}, {p.City}"));
    }
}
