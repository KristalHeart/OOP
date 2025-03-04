using System;
using System.Collections.Generic;

class Person
{
    public string Name;
    public int Age;
    public int Id;
    public string BirthYear;

    private static int Counter = 0;
    private static Dictionary<int, Person> Database = new Dictionary<int, Person>();

    public Person(string name, int age, string birthyear)
    {
        Name = name;
        Age = age;
        BirthYear = birthyear;
        Counter++;
        Id = Counter;
        Database[Id] = this;
    }

    public static string GetInfo(int id)
    {
        if (Database.TryGetValue(id, out Person person))
        {
            return $"Личный номер: {person.Id}, ФИО: {person.Name}, Год рождения: {person.BirthYear}, Возраст: {person.Age}";
        }
        else
        {
            return "Человек не найден.";
        }
    }
}

class Student : Person
{
    public int UniId1 { get; set; }

    public Student(string name, int age, string birthyear) : base(name, age, birthyear)
    {
    }

    public string GetStudentInfo()
    {
        return $"Личный номер: {Id}, ФИО: {Name}, Год рождения: {BirthYear}, Возраст: {Age}, Номер зачетной книжки: {UniId1}";
    }
}

class University
{
    public static int UniCounter = 0;
    private List<Student> Students = new List<Student>();

    public void AddStudent(Student student)
    {
        UniCounter++;
        student.UniId1 = UniCounter;
        Students.Add(student);
    }

    public string GetStudentInfo(int id)
    {
        foreach (var student in Students)
        {
            if (student.Id == id)
            {
                return $"Личный номер: {student.Id}, ФИО: {student.Name}, Год рождения: {student.BirthYear}, Номер зачётной книжки: { student.UniId1}";
            }
        }
        return "Студент не найден.";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person("Иван", 19, "2004");
        Student student = new Student("Анна", 22, "2001");

        Console.WriteLine(Person.GetInfo(person.Id));

        University university = new University();
        university.AddStudent(student);

        Console.WriteLine(student.GetStudentInfo());
        Console.WriteLine(university.GetStudentInfo(student.Id));
    }
}