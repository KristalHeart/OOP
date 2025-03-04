using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace лаб_7
{
    public class Plan
    {
        private List<Shape> shapes = new List<Shape>();
        public void Add(Shape shape)
        {
            shapes.Add(shape);
        }
        public void GetStatistics()
        {
            int RectanglesCount = 0;
            int CirclesCount = 0;
            int TrianglesCount = 0;
            foreach (var shape in shapes)
            {
                if (shape is Rectangle)
                {
                    RectanglesCount++;
                }
                else if (shape is Circle)
                {
                    CirclesCount++;
                }
                else if (shape is Triangle)
                {
                    TrianglesCount++;
                }
            }
        }
    }
    public class Shape
    {
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public override string ToString()
        {
            Console.WriteLine($"Площадь: {Area}, Периметр: {Perimeter}");
            return ($"Площадь: {Area}, Периметр: {Perimeter}");
        }
    }
    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public void area()
        {
            Area = Width * Height;
        }
        public void perimeter()
        {
            Perimeter = 2 * (Width + Height);
        }
        public override string ToString()
        {
            Console.WriteLine($"Прямоугольник Ширина: {Width}, Высота: {Height}, Площадь: {Area}, Периметр: {Perimeter}");
            return $"Прямоугольник Ширина: {Width}, Высота: {Height}, Площадь: {Area}, Периметр: {Perimeter}";
        }
    }
    public class Circle : Shape
    {
        public int Radius { get; set; }
        public void area()
        {
            Area = Math.PI * Radius * Radius;
        }
        public override string ToString()
        {
            Console.WriteLine($"Круг Радиус: {Radius}, Площадь: {Area}, Периметр: {Perimeter}");
            return $"Круг Радиус: {Radius}, Площадь: {Area}, Периметр: {Perimeter}";
        }
    }
    public class Triangle : Shape
    {
        public int SideA { get; set; }
        public int SideB { get; set; }
        public int SideC { get; set; }
        public void perimeter()
        {
            Perimeter = SideA + SideB + SideC;
        }
        public void area()
        {
            double s = Perimeter / 2;
            Area = Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }
        public override string ToString()
        {
            Console.WriteLine($"Треугольник SideA: {SideA}, SideB: {SideB}, SideC: { SideC}, Площадь: { Area}, Периметр: { Perimeter}");
        return $"Треугольник SideA: {SideA}, SideB: {SideB}, SideC: {SideC}, Площадь: {Area}, Периметр: { Perimeter}";
        }
    }
    public class Program {
        static void Main()
        {
            Plan NewPlan = new Plan();
            Shape NewShape = new Shape { Area = 64, Perimeter = 128 };
            NewShape.ToString();
            Rectangle Rect = new Rectangle { Width = 3, Height = 5 };
            Rect.area();
            Rect.perimeter();
            Rect.ToString();
            Circle Circle = new Circle { Radius = 4 };
            Circle.area();
            Circle.ToString();
            Circle Circle2 = new Circle { Radius = 6 };
            Triangle Triangle = new Triangle { SideA = 3, SideB = 4, SideC = 5 };
            Triangle.perimeter();
            Triangle.area();
            Triangle.ToString();
            NewPlan.Add(Rect);
            NewPlan.Add(Circle);
            NewPlan.Add(Circle2);
            NewPlan.Add(Triangle);
            NewPlan.GetStatistics();
        }
    } 
}

