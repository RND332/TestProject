using Xunit;
using FiguresLibary;
using System;

namespace TestProject.Testes
{
    public class TestCircle
    {
        [Fact]
        public void TestCircleArea()
        {
            var circle = new Circle(2);
            Assert.Equal(12.57, Math.Round(circle.GetArea(), 2));
        }

        [Fact]
        public void TestWrongCircleAreaLowerZero()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Circle(-2));
            Assert.Equal("Радиус должен быть больше 0", exception.Message);
        }

        [Fact]
        public void TestWrongCircleAreaZero()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Circle(0));
            Assert.Equal("Радиус должен быть больше 0", exception.Message);
        }
    }
    public class TestTriangle 
    {
        [Fact]
        public void TestTriangleArea()
        {
            var triangle = new Triangle(new double[] { 2, 3, 4 });
            Assert.Equal(2.90, Math.Round(triangle.GetArea(), 2));
        }

        [Fact]
        public void TestWrongTriangleAreaLowerZero()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Triangle(new double[] { -2, 3, 4}));
            Assert.Equal("Одна из сторон меньше или равна 0", exception.Message);
        }

        [Fact]
        public void TestWrongTriangleAreaZero()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Triangle(new double[] { 0, 3, 4}));
            Assert.Equal("Одна из сторон меньше или равна 0", exception.Message);
        }

        [Fact]
        public void TestRectangularTriangle() 
        {
            var triangle = new Triangle(new double[] { 7.07, 7.07, 10 });
            Assert.True(triangle.IsRectangular());
        }

        [Fact]
        public void TestCorners() 
        {
            var triangle = new Triangle(new double[] { 7.07, 7.07, 10 });
            Assert.Equal(new double[] { 90, 45, 45 }, triangle.GetCorners());
        }
    }
    public class TestSquare 
    {
        [Fact]
        public void TestSquareArea()
        {
            var square = new Square(new double[] { 2, 2 });
            Assert.Equal(4, square.GetArea());
        }

        [Fact]
        public void TestWrongSquareAreaLowerZero()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Square( new double[] { -2, 3, 4 }));
            Assert.Equal("Сторона должна быть больше 0", exception.Message);
        }

        [Fact]
        public void TestWrongSquareAreaZero()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Square( new double[] { -2, 3, 4 }));
            Assert.Equal("Сторона должна быть больше 0", exception.Message);
        }
    }
    public class TestFigureFacility 
    {
        [Fact]
        public void TestFigureFacilityGetUnknownFigureArea()
        {
            Assert.Equal(2.90, Math.Round(FigureFacility.GetUnknownFigureArea(new double[] { 2, 3, 4 }), 2));
        }

        [Fact]
        public void TestWrongFigureFacilityGetUnknownFigureArea()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => FigureFacility.GetUnknownFigureArea(new double[] { 2, 3, 4, 5 }));
            Assert.Equal("Неверное количество аргументов", exception.Message);
        }

        [Fact]
        public void TestFigureFacilityGetUnknownFigureObjectCircle() 
        {
            Assert.Equal(typeof(Circle), FigureFacility.GetUnknownFigureObject(new double[] { 2 }).GetType());
        }

        [Fact]
        public void TestFigureFacilityGetUnknownFigureObjectSquare() 
        {
            Assert.Equal(typeof(Square), FigureFacility.GetUnknownFigureObject(new double[] { 2, 3 }).GetType());
        } 

        [Fact]
        public void TestFigureFacilityGetUnknownFigureObjectTriangle() 
        {
            Assert.Equal(typeof(Triangle), FigureFacility.GetUnknownFigureObject(new double[] { 2, 3, 4 }).GetType());
        }

        [Fact]
        public void TestWrongFigureFacilityGetUnknownFigureObject()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => FigureFacility.GetUnknownFigureObject(new double[] { 2, 3, 4, 5 }));
            Assert.Equal("Неверное количество аргументов", exception.Message);
        }
    }
}