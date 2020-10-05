using System;

namespace Task5
{
    class Program
    {
        
        abstract class Figure
        {
            public virtual double ComputeArea()
            {
                return 0;
            }
            public virtual double ComputePerimeter()
            {
                return 0;
            }

        }
        
        class Triangle : Figure
        {
            public Triangle(double side1, double side2, double side3)
            {
                if (!IfTriangle(side1, side2, side3))
                {
                    Console.WriteLine("Side1, side2 and side 3 does not require to be triangle");
                    return;
                }
                Side1 = side1;
                Side2 = side2;
                Side3 = side3;
            }
            
            private bool IfTriangle(double side1, double side2, double side3)
            {
                return (side1 + side2 > side3) && (side1 + side3 > side2) && (side2 + side3 > side1);
            }

            public override double ComputePerimeter()
            {
                return Side1 + Side2 + Side3;
            }

            public override double ComputeArea()
            {
                double p = ComputePerimeter() / 2;
                return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
            }

            public static double Side1 { get; set; }
            public static double Side2 { get; set; }
            public static double Side3 { get; set; }

        }

        class Circle : Figure
        {
            public Circle(double radius)
            {
                Radius = radius;
            }

            public override double ComputeArea()
            {
                return Math.PI * Radius * Radius;
            }

            public override double ComputePerimeter()
            {
                return 2 * Math.PI * Radius;
            }

            public double Radius;
        }

        private class Rectangle : Figure
        {
            public Rectangle(double side1, double side2)
            {
                Side1 = side1;
                Side2 = side2;
            }

            public override double ComputeArea()
            {
                return Side1 * Side2;
            }

            public override double ComputePerimeter()
            {
                return 2 * (Side1 + Side2);
            }

            public double Side1;
            public double Side2;
        }

        class Square : Figure
        {
            public Square(double side)
            {
                Side = side;
            }

            public override double ComputeArea()
            {
                return Side * Side;
            }

            public override double ComputePerimeter()
            {
                return 4 * Side;
            }

            private double Side;
        }

        class Rhombus : Figure
        {
            public Rhombus(double side, double smallerAngle)
            {

                if (smallerAngle > 90)
                {
                    SmallerAngle = 180 - smallerAngle;
                }
                Side = side;
                SmallerAngle = smallerAngle * Math.PI / 180;
            }

            public override double ComputeArea()
            {
                return Side * Side * Math.Sin(SmallerAngle);
            }

            public override double ComputePerimeter()
            {
                return 4 * Side;
            }

            public double Side;
            public double SmallerAngle;
        }


        static void Main()
        {
            Triangle triangle = new Triangle(10, 8, 60);
            Console.WriteLine("Triangle, area = {0}, perimeter = {1}", triangle.ComputeArea(),
                triangle.ComputePerimeter());

            Circle circle = new Circle(10);
            Console.WriteLine("Circle, area = {0}, perimeter = {1}", circle.ComputeArea(),
                circle.ComputePerimeter());

            Rectangle rectangle = new Rectangle(10, 20);
            Console.WriteLine("Rectangle, area = {0}, perimeter = {1}", rectangle.ComputeArea(),
                rectangle.ComputePerimeter());
            
            Square square = new Square(10);
            Console.WriteLine("Square, area = {0}, perimeter = {1}", square.ComputeArea(),
                square.ComputePerimeter());
            
            Rhombus rhombus = new Rhombus(10, 60);
            Console.WriteLine("Rhombus, area = {0}, perimeter = {1}", rhombus.ComputeArea(),
                rhombus.ComputePerimeter());
        }
    }
}