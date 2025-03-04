using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
#nullable enable

namespace лаба_6
{
    internal class Program
    {
        //1
        class NullElements
        {
            #pragma warning disable CS8618 //11
            public string String { get; set; }
            //public string String { get; }
            #pragma warning restore CS8618
            public int Int { get; set; }
            public double Double { get; set; }
            public string? NullString { get; set; }
            public int? NullInt { get; set; }
            public double? NullDouble { get; set; }

            public void NullElement(string Str, int int1, double double1, string nullString1, int? nullInt1, double? nullDouble1)
            {
                String = Str; //?? throw new ArgumentNullException(nameof(String), "Строка не может быть null"); //5
                Int = int1;
                Double = double1;
                NullString = nullString1;
                NullInt = nullInt1;
                NullDouble = nullDouble1;
            }
            //2
            public void PrintInfo()
            {
                Console.WriteLine(String ?? "Значения нет");
                Console.WriteLine(Int.ToString() ?? "Значения нет");
                Console.WriteLine(Double.ToString() ?? "Значения нет");
                Console.WriteLine(NullString ?? "Значения нет");
                Console.WriteLine(NullInt?.ToString() ?? "Значения нет");
                Console.WriteLine(NullDouble?.ToString() ?? "Значения нет");
                Console.WriteLine("--------------------");
            }
        }
        //8 Напишите функцию, которая принимает экземпляр класса и присваивает его nullable свойству какое либо значение, если значение null. Воспользуйтесь '??='

        static void SetNullableValue(NullElements NonnullElement)
        {
            NonnullElement.NullString ??= "Default Value";
            NonnullElement.NullInt ??= 0;
            NonnullElement.NullDouble ??= 0.5;
        }
        //9 Напишите функцию, которая принимает экземпляр класса. Аргумент экземпляра nullable.Функция возвращает значение некоторого свойства. Если в метод был передан null, то возвращает какую-либо константу. Воспользуйтесь '?.'
        static int GetNullProperty(NullElements? NullEl1)
        {
            return NullEl1?.Int ?? -1;
        }
        //10 Напишите функцию, которая принимает экземпляр класса. Функция возвращает значение некоторого nullable свойства.Если значение свойства null, то возвращает какую-либо константу.Воспользуйтесь '??';
        static int GetNullProperty2(NullElements nullEl2)
        {
            return nullEl2.NullInt ?? -1;
        }
        static void Main(string[] args)
        {
            //3
            NullElements example1 = new NullElements();
            example1.NullElement("Grass", 45, 12.5, null, null, null);
            //4
            example1.PrintInfo();
            //6
            NullElements example2 = new NullElements();
            example2.NullElement(null, 45, 23.4, "45", 45, 45.5);
            example2.PrintInfo();

            NullElements example3 = new NullElements();
            example3.NullElement("jam", 456, 462.2, "456", 56, null);
            example3.PrintInfo();
            //6 задание: поменять Int Double на null(!)
            // 7 При попытке присвоить null свойству, которое не может принимать null, возникает ошибка компиляции.
            // При использовании оператора "!" после null, компилятор не будет проверять на null, но это может привести к ошибкам во время выполнения, если значение действительно null.
            //8:
            SetNullableValue(example1);
            example1.PrintInfo();
            //9:
            int value = GetNullProperty(example1);
            Console.WriteLine("GetNullableProperty: " + value);
            //10:
            value = GetNullProperty2(example1);
            Console.WriteLine("GetNullableProperty2: " + value);
            //6:
            int length = example3.String.Length;
            Console.WriteLine("Length: " + length);
        }
    }
}
