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
# Testes
Run testes with `dotnet test`
## List of testes: 
>TestCircle - `circle functions testes`
>>TestCircleArea - `checking the correctness of calculations for the area of the circle`
>>
>>TestWrongCircleAreaLowerZero - `checking exception raidus <= 0`
>>
>>TestWrongCircleAreaZero - `checking exceptions raidus <= 0`
--------------------------
>TestTriangle - `triangle functions testes`
>>TestTriangleArea - `checking the correctness of calculations for the area of the triangle`
>>
>>TestWrongTriangleAreaLowerZero - `checking exception a, b or c <= 0`
>>
>>TestWrongTriangleAreaZero - `checking exception a, b or c <= 0`
>>
>>TestRectangularTriangle - `checking correction recognition of right triangles`
>>
>>TestCorners - `checking the correctness of the calculation of the angles of the triangle`
--------------------------
>TestSquare - `square functions testes`
>>
>>TestSquareArea - `checking the correctness of calculations for the area of the square`
>>
>>TestWrongSquareAreaLowerZero - `checking exception a <= 0`
>>
>>TestWrongSquareAreaZero - `checking exception a <= 0`
--------------------------
>TestFigureFacility - `FigureFacility functions testes`
>>
>>TestFigureFacilityGetUnknownFigureArea - `checking the correctness of the calculation of the angles of the triangle`  
>>
>>TestWrongFigureFacilityGetUnknownFigureArea - `checking exception leight of arguments <= 0 or > 3`  
>>
>>TestFigureFacilityGetUnknownFigureObjectCircle - `checking whether the factory returns a circle if the number of arguments is 2`  
>>
>>TestFigureFacilityGetUnknownFigureObjectSquare - `checking whether the factory returns a square if the number of arguments is 2`  
>>
>>TestFigureFacilityGetUnknownFigureObjectTriangle - `checking whether the factory returns a triangle if the number of arguments is 3`  
>>
>>TestWrongFigureFacilityGetUnknownFigureObject - `checking exception leight of arguments <= 0 or > 3`  
