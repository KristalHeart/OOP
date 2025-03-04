using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_4
{
    public class MyClass
    {
        // Свойство типа string, короткой записи 
        public string ShortProperty { get; set; }

        // Свойство типа string с использованием полной записи, включая геттер и сеттер
        public string fullProperty;
        public string FullProperty
        {
            get { return fullProperty; }
            set { fullProperty = value; }
        }

        // Свойство типа int с использованием полной записи, нельзя установить отрицательные значения
        public int intProperty;
        public int IntProperty
        {
            get { return intProperty; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Значение не может быть отрицательным.");
                }
                intProperty = value;
            }
        }

        // bool, предыдущий инт меньше 25
        public bool IsLessThan25
        {
            get { return IntProperty < 25; }
        }
        // Перегруженный метод GetInfo, возвращающий информацию о всех свойствах
        public string GetInfo()
        {
            return $"Короткая запись: {ShortProperty}, Полная запись: {fullProperty}, Неотрицательное значение: {intProperty}, Булевое значение: {IsLessThan25}";
        }

        // Перегруженный метод GetInfo, включающий условие для инт
        public string GetInfo(bool includeIntProperty)
        {
            if (includeIntProperty)
            {
                return $"Короткая запись: {ShortProperty}, Полная запись: {fullProperty}, Неотрицательное значение: {intProperty}, Булевое значение: {IsLessThan25}";
            }
            else
            {
                return $"Короткая запись: {ShortProperty}, Полная запись: {fullProperty}";
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр DescriptiveClass
            MyClass Class1 = new MyClass();
            {
                Class1.ShortProperty = "Это короткое описание.";
                Class1.fullProperty = "Это полное описание.";
                Class1.intProperty = 25;
            };

            // Вызываем первый метод GetInfo без параметров
            string infoWithAllProperties = Class1.GetInfo();
            Console.WriteLine(infoWithAllProperties);

            // Вызываем второй метод GetInfo с параметром, чтобы исключить IntValue
            string infoWithoutIntValue = Class1.GetInfo(true);
            Console.WriteLine(infoWithoutIntValue);
        }
    }
}
