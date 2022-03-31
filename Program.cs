using System;

namespace TestProgram
{
    public class Circle : IFigure
    {
        public double Raidius { get; private set; }

        public double GetArea() // метод вычисления площади круга
        {
            return Raidius * Raidius * Math.PI;
        }

        public Circle(double Raidius)
        {
            if(Raidius <= 0) throw new ArgumentException("Радиус должен быть больше 0");

            this.Raidius = Raidius;
        }
    }

    public class Triangle : IFigure
    {
        public double[] Sides = new double[3];
        public double[] Corners = new double[3];

        public bool IsRectangular() // Является ли триугольник прямоугольным
        {
            return Corners.Any(x => x == 90); // Если одна из сторон равна 90 градусов
        }

        public double GetArea() // Площадь треугольника
        {
            if(IsRectangular()) // Площать прямоугольного треугольника 
            {
                return (Sides[0] * Sides[1]) / 2;
            }
            else
            {
                double p = (Sides[0] + Sides[1] + Sides[2]) / 2; // Полупериметр
                return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
            }
        }

        public double[] GetCorners() // Найти углы треугольника по его сторонам
        {
            double[] corners = new double[3];

            double a = Sides[0];
            double b = Sides[1];
            double c = Sides[2];

            if (!(a + b > c && a + c > b && b + c > a)) throw new ArgumentException("Треугольник не существует"); // Проверка на существование треугольника

            corners[0] = Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b)) * 180 / Math.PI; // Угол А
            corners[1] = Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c)) * 180 / Math.PI; // Угол В
            corners[2] = Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c)) * 180 / Math.PI; // Угол С

            return corners;
        }

        public Triangle(double[] sides)
        {
            if(sides.Length != 3) throw new ArgumentException("Количество сторон не равно 3"); // Если количество сторон не равно 3
            if(sides.Any(x => x <= 0)) throw new ArgumentException("Одна из сторон меньше или равна 0"); // Если одна из сторон меньше или равна 0

            this.Sides = sides; // Сохраняем в поле сторон
            this.Corners = GetCorners(); // Сохраняем в поле углы
        }
    }

    public class FigureFacility 
    {
        public static double GetUnknownFigureArea(params double[] arguments) // Получить площадь фигуры
        {
            if(arguments.Length == 3) // Если переданы три аргумента то это треугольник
            {
                return new Triangle(arguments).GetArea();
            }
            else if(arguments.Length == 1) // Если передан один аргумент то это круг
            {
                return new Circle(arguments.First()).GetArea();
            }
            else throw new ArgumentException("Неверное количество аргументов"); // Если передано неверное количество аргументов
        }
        
        public static IFigure GetUnknownFigureObject(params double[] arguments)
        {
            if(arguments.Length == 3) // Если переданы три аргумента то это треугольник
            {
                return new Triangle(arguments);
            }
            else if(arguments.Length == 1) // Если передан один аргумент то это круг
            {
                return new Circle(arguments.First());
            }
            else throw new ArgumentException("Неверное количество аргументов"); // Если передано неверное количество аргументов
        }
    }

    public interface IFigure
    {
        double GetArea();
    }
}
