using System;

namespace Task6
{
    class Program
    {
        
        abstract class Triangle
        {

            public Triangle(double side1, double side2, double angle)
            {
                Side1 = side1;
                Side2 = side2;
                Angle = angle * Math.PI / 180;
            }
            public virtual double ComputeArea()
            {
                return Side1 * Side2 * Math.Sin(Angle) / 2;
            }

            public virtual double ComputePerimeter()
            {
                return Side1 + Side2 + Math.Sqrt(Side1 * Side1 + Side2 * Side2 - 2 * Side1 * Side2 * Math.Cos(Angle));
            }
            
            public double Side1;
            public double Side2;
            public double Angle;
        }

        class RightAngledTriangle : Triangle
        {
            public RightAngledTriangle(double side1, double side2, double angle) : base(side1, side2, angle)
            {
                Side1 = side1;
                Side2 = side2;
                Angle = angle * Math.PI / 180;
            }
            
            public override double ComputeArea()
            {
                if (!(Angle < 90)) return Side1 * Side2 / 2;
                if (Side1 > Side2)
                {
                    return Math.Sqrt(Side1 * Side1 - Side2 * Side2) * Side2;
                }

                return Math.Sqrt(Side2 * Side2 - Side1 * Side1) * Side1;
            }
        }

        class IsoscelesTriangle : Triangle
        {
            public IsoscelesTriangle(double side1, double side2, double angle) : base(side1, side2, angle)
            {
                Side1 = side1;
                Side2 = side2;
                Angle = angle * Math.PI / 180;
            }

            public override double ComputeArea()
            {
                if (Side1 == Side2)
                {
                    return Side1 * Side1 * Math.Sin(Angle) / 2;
                }

                double side3 = Math.Sqrt(Side1 * Side1 + Side2 * Side2 - 2 * Side1 * Side2 * Math.Cos(Angle));
                if (side3 == Side1)
                {
                    return Side2 * Math.Sqrt(side3 * side3 - Side2 * Side2 / 4) / 2;
                }

                return Side1 * Math.Sqrt(side3 * side3 - Side1 * Side1 / 4) / 2;
            }

            public override double ComputePerimeter()
            {
                double side3 = Math.Sqrt(Side1 * Side1 + Side2 * Side2 - 2 * Side1 * Side2 * Math.Cos(Angle));
                
                if (Side1 == Side2)
                {
                    return 2 * Side1 + side3;
                }

                if(Side1 == side3)
                {
                    return 2 * Side1 + Side2;
                }

                return 2 * Side2 + Side1;
            }
        }
        
        static void Main()
        {
            Triangle triangle = new IsoscelesTriangle(10, 8, 60);
            Console.WriteLine("Common triangle, area = {0}, perimeter = {1}", triangle.ComputeArea(), triangle.ComputePerimeter());
            
            RightAngledTriangle rtriengle = new RightAngledTriangle(10, 8, 60);
            Console.WriteLine("Right Angled triangle, area = {0}, perimeter = {1}", rtriengle.ComputeArea(), rtriengle.ComputePerimeter());
            
            IsoscelesTriangle itriengle = new IsoscelesTriangle(10, 8, 60);
            Console.WriteLine("Isosceles triangle, area = {0}, perimeter = {1}", itriengle.ComputeArea(), itriengle.ComputePerimeter());
        }
    }
}