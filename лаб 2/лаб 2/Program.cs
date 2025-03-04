using System.Collections.Generic;
using System.Xml.Linq;
public struct Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }

    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Название: {Title}, Автор: {Author}, ISBN: {ISBN}");
    }
    public Book WithTitle(string newTitle)
    {
        return this with { Title = newTitle };
    }

    public Book WithAuthor(string newAuthor)
    {
        return this with { Author = newAuthor };
    }

    // Метод для изменения ISBN
    public Book WithISBN(string newIsbn)
    {
        return this with { ISBN = newIsbn };
    }
}

public class LibraryUser
{
    public string Name { get; set; }
    public int UserId { get; set; }
    

    public LibraryUser(string name, int userId)
    {
        Name = name;
        UserId = userId;
        
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Имя: {Name}, ID: {UserId}");
    }

    // Метод для создания нового экземпляра LibraryUser с изменённым именем
    public LibraryUser CreateCopyWithNewName(string newName)
    {
        return new LibraryUser(newName, this.UserId);
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Создание книги
        Book book1 = new Book("1984", "George Orwell", "978-0451524935");
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "978-0061120084");
        book1.DisplayInfo();
        book2.DisplayInfo();

        // Создание пользователя библиотеки
        LibraryUser user = new LibraryUser("Alice", 1);

        user.DisplayInfo();

        // Копирование и изменение имени пользователя
        LibraryUser newUser = user.CreateCopyWithNewName("Bob");
        newUser.DisplayInfo();

        // Копирование книги с измененным автором
        Book modifiedBook = book2.WithAuthor("Harper Lee (Edited)");
        modifiedBook.DisplayInfo();
        user.DisplayInfo();
    }
}
