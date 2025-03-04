using System;
class Person
{
    public string name = "Ben";
    public int age = 18;
    public string email = "ben@gmail.com";
    public Person(string name)
    {
        this.name = name;
    }
    public Person(string name, int age) : this(name)
    {
        this.age = age;
    }
    public Person(string name, int age, string email) :
    this("Bob", age)
    {
        this.email = email;
    }

}
class Program
{
    static void Main(string[] args)
    {
        Person person = new Person("Alice", 25, "alice@example.com");
        Console.WriteLine($"Name: {person.name}, Age: {person.age}, Email: {person.email}");
    }
}