using System;

namespace GeometryLibrary
{
    public interface IShape
    {
        double CalculateArea();
    }

    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * radius * radius;
        }
    }

    public class Triangle : IShape
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public double CalculateArea()
        {
            double semiPerimeter = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
        }

        public bool IsRightTriangle()
        {
            double[] sides = { sideA, sideB, sideC };
            Array.Sort(sides);

            return (sides[2] * sides[2] == sides[0] * sides[0] + sides[1] * sides[1]);
        }
    }

    // Дополнительные фигуры можно добавить, реализуя интерфейс IShape

    public class Program
    {
        public static void Main(string[] args)
        {
            // Пример использования библиотеки
            double radius = 5;
            Circle circle = new Circle(radius);
            double circleArea = circle.CalculateArea();
            Console.WriteLine($"Площадь круга с радиусом {radius} равна {circleArea}");

            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            double triangleArea = triangle.CalculateArea();
            Console.WriteLine($"Площадь треугольника с сторонами {sideA}, {sideB}, {sideC} равна {triangleArea}");

            bool isRightTriangle = triangle.IsRightTriangle();
            Console.WriteLine($"Треугольник с сторонами {sideA}, {sideB}, {sideC} является прямоугольным: {isRightTriangle}");
        }
    }
}
