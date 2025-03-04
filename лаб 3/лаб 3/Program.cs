using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DataAccess;

public class Student
{
    private string _firstName;
    private string _lastName;
    private int _age;
    private double _averageGrade;
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }
    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }
    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }
    public double AverageGrade
    {
        get { return _averageGrade; }
        set { _averageGrade = value; }
    }
    public Student(string firstName, string lastName, int age, double averageGrade)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        AverageGrade = averageGrade;
    }
}
public class University
{
    private List<Student> _students;
    public University()
    {
        _students = new List<Student>();
    }
    public void AddStudent(Student student)
    {
        _students.Add(student);
    }
    public void RemoveStudent(Student student)
    {
        _students.Remove(student);
    }
    public Student FindStudent(string firstName, string lastName)
    {
        return _students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
    }
    public List<Student> GetAllStudents()
    {
        return _students;
    }
}
namespace DataAccess
{
    public class StudentsRepository
    {
        private readonly string _filePath;

        public StudentsRepository(string filePath)
        {
            _filePath = filePath;
        }
        // Метод для сохранения студентов в файл
        public void SaveStudents(List<Student> students)
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(students);
                File.WriteAllText(_filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении студентов: {ex.Message}");
            }
        }
        // Метод для загрузки студентов из файла
        public List<Student> LoadStudents()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    var jsonString = File.ReadAllText(_filePath);
                    return JsonSerializer.Deserialize<List<Student>>(jsonString);
                }
                else
                {
                    return new List<Student>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке студентов: {ex.Message}");
                return new List<Student>();
            }
        }
    }
}
namespace лаб_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задаем путь к файлу, где будут храниться студенты
            string filePath = "students.json";
            StudentsRepository repository = new StudentsRepository(filePath);

            // Создаем список студентов
            List<Student> students = new List<Student>
            {
                new Student("John", "Doe", 20, 3.5),
                new Student("Jane", "Doe", 22, 3.8)
            };

            // Сохраняем студентов в файл
            repository.SaveStudents(students);

            // Загружаем студентов из файла
            List<Student> loadedStudents = repository.LoadStudents();

            // Выводим информацию о загруженных студентах
            foreach (var student in loadedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} - Age: {student.Age}, Average Grade: {student.AverageGrade}");
            }
        }
    }
}

