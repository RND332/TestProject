# TestProject
Project for a vacancy

# Using

## class Circle 
``` csharp
var circle = new Circle(3);
Console.WriteLine(circle.GetArea());
```
And you will get `12.566371` which is area of circle with radius 3

## class Triangle
``` csharp
var sides = new double[] { 2, 3, 4 };
var circle = new Triangle(sides);
Console.WriteLine(circle.GetCorners());
Console.WriteLine(circle.GetArea());
```
And you will get `90`, `36.87`, `53.13` which is corners for trianle with `2, 3, 4` sides and `6` whis is area for this trianle

## class FigureFacility
```csharp 
var Figure = FigureFacility.GetUnknownFigureObject(2);
Console.WriteLine(Figure.GetArea()); // 12.566371 area of circle
```

```csharp 
var Figure = FigureFacility.GetUnknownFigureObject(2, 3, 4);
Console.WriteLine(Figure.GetArea()); // 6 area of triangle
```

```csharp 
var Figure = FigureFacility.GetUnknownFigureArea(2);
Console.WriteLine(Figure); // 12.566371 area of circle
```

```csharp 
var Figure = FigureFacility.GetUnknownFigureArea(2, 3, 4);
Console.WriteLine(Figure); // 6 area of triangle
```

## interface IFigure
```csharp 
class Square : IFigure
{
  public double Side { get; pricate set; }
  public double GetArea()
  {
    return this.Side ^ 2;
  }
  public Square(double side)
  {
    this.Side = Side;
  }
}
```
