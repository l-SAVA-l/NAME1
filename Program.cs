using System;
using System.Collections.Generic;

abstract class Goods : IComparable<Goods> // Абстрактный класс с методом CompareTo
{
    // Свойства класса 
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Age { get; set; } 
    // Конструктор 
    public Goods(string name, decimal price, int age)
    {
        Name = name;
        Price = price;
        Age = age;
    }

    // Вбстрактный метод для вывода информации
    public abstract void DisplayInfo();

    // Абстрактный метод для проверки, относится ли товар к определённому типу
    public abstract bool IsOfType(string type);

    // ласс Goods реализует интерфейс IComparable<Goods>,
    // что позволяет сравнивать объекты этого типа для сортировки.
    // Сравненеи по полю AGE
    public int CompareTo(Goods other)
    {
        return this.Age.CompareTo(other.Age);
    }
}

class Toy : Goods // Класс игрушка, наследник класса GOODs
{
    // Свойства класса наследника 
    public string Manufacturer { get; set; }
    public string Material { get; set; }
    // Конструктор класса наследника 
    public Toy(string name, decimal price, string manufacturer, string material, int age)
        : base(name, price, age)
    {
        Manufacturer = manufacturer;
        Material = material;
    }
    // Метод класса Вывод информации об игрушке 
    public override void DisplayInfo()
    {
        Console.WriteLine($"Toy: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, Material: {Material}, Age: {Age}+");
    }
    // Этот метод проверяет, является ли товар игрушкой, возвращая true,
    // если переданный тип равен "toy"
    public override bool IsOfType(string type)
    {
        return type.ToLower() == "toy";
    }
}

class Book : Goods // Класс игрушка, наследник класса GOODs
{
    // Свойства класса наследника 
    public string Author { get; set; }
    public string Publisher { get; set; }
    // Конструктор класса наследника
    public Book(string name, string author, decimal price, string publisher, int age)
        : base(name, price, age)
    {
        Author = author;
        Publisher = publisher;
    }
    // Метод класса Вывод информации об игрушке 
    public override void DisplayInfo()
    {
        Console.WriteLine($"Book: {Name}, Author: {Author}, Price: {Price}, Publisher: {Publisher}, Age: {Age}+");
    }
    // Этот метод проверяет, является ли товар книгой, возвращая true,
    // если переданный тип равен "BOOk"
    public override bool IsOfType(string type)
    {
        return type.ToLower() == "book";
    }
}

class SportsEquipment : Goods // Класс спортивное снаряжение, наследник класса GOODs
{
    // Свойства 
    public string Manufacturer { get; set; }
    // конструктор 
    public SportsEquipment(string name, decimal price, string manufacturer, int age)
        : base(name, price, age)
    {
        Manufacturer = manufacturer;
    }
    // Вывод
    public override void DisplayInfo()
    {
        Console.WriteLine($"Sports Equipment: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, Age: {Age}+");
    }
    // Метод проверки
    public override bool IsOfType(string type)
    {
        return type.ToLower() == "sportsequipment";
    }
}

class Program
{
    static void Main()
    {
        // создем список товаров класса Goods 
        List<Goods> goodsList = new List<Goods>
        {
           new Toy("Конструктор Лего", 29.99m, "Lego", "Пластик", 7),
           new Book("Гарри Поттер", "Дж. К. Роулинг", 19.99m, "Блумсбери", 10),
           new SportsEquipment("Футбольный мяч", 14.99m, "Nike", 8),
           new Toy("Плюшевый мишка", 9.99m, "ToysCo", "Плюш", 3),
           new Book("Хоббит", "Дж. Р. Р. Толкин", 25.99m, "Houghton Mifflin", 12)
        };

        // сортируем список 
        goodsList.Sort();

        // Выводим отсортированный список
        Console.WriteLine("Goods отсортированный по age:");
        foreach (Goods goods in goodsList)
        {
            goods.DisplayInfo();
        }

        // поиск товаров по типу
        Console.WriteLine("Введите тип для поиска(toy,sportsequipment,book) ");
        string prs = Console.ReadLine();
        string searchType = prs ; 
        Console.WriteLine($"\nОбъекты: {searchType}");
        foreach (Goods goods in goodsList)
        {
            if (goods.IsOfType(searchType))
            {
                goods.DisplayInfo();
            }
        }
    }
}
