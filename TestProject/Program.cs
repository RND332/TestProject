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

    public class Square : IFigure 
    {
        public double[] Sides = new double[2];

        public double GetArea() // Площадь квадрата
        {
            return Sides[0] * Sides[1];
        }

        public Square(double[] Sides)
        {
            if(Sides[0] <= 0 || Sides[1] <= 0) throw new ArgumentException("Сторона должна быть больше 0"); // Если сторона меньше или равна 0

            this.Sides = Sides;
        }
    }

    public class FigureFacility 
    {
        public static double GetUnknownFigureArea(params double[] arguments) // Получить площадь фигуры
        {
            switch (arguments.Length)
            {
                case 1:
                    return new Circle(arguments.First()).GetArea(); // Если передан один аргумент - это радиус круга
                case 2:
                    return new Square(arguments).GetArea(); // Если переданы два аргумента - это стороны квадрата
                case 3:
                    return new Triangle(arguments).GetArea(); // Если переданы три аргумента - это стороны треугольника
                default:
                    throw new ArgumentException("Неверное количество аргументов"); // Если передано неверное количество аргументов
            }
        }

        public static IFigure GetUnknownFigureObject(params double[] arguments)
        {
            switch (arguments.Length)
            {
                case 1:
                    return new Circle(arguments.First()); // Если передан один аргумент - это радиус круга
                case 2:
                    return new Square(arguments); // Если переданы два аргумента - это стороны квадрата
                case 3:
                    return new Triangle(arguments); // Если переданы три аргумента - это стороны треугольника
                default:
                    throw new ArgumentException("Неверное количество аргументов"); // Если передано неверное количество аргументов
            }
        }
    }

    public interface IFigure
    {
        double GetArea();
    }
}
