using System;

namespace Task4
{
    class Program
    {
        private static bool IfTriangle(double side1, double side2, double side3)
        {
            return (side1 + side2 > side3) && (side1 + side3 > side2) && (side2 + side3 > side1);
        }

        class EquilateralTriangle : Triangle
        {
            public EquilateralTriangle(double side) : base(side, side, side)
            {
                Side1 = side;
                Side2 = side;
                Side3 = side;
            }

            public double Area = Side1 * Side2 * Math.Sqrt(3) / 4 ;
        }
        
        class Triangle
        {
            public Triangle(double side1, double side2, double side3)
            {
                if (!IfTriangle(side1, side2, side3)) return;
                Side1 = side1;
                Side2 = side2;
                Side3 = side3;
            }

            public void ChangeSide(double value, int siteNumber)
            {
                switch (siteNumber)
                {
                    case 1 when IfTriangle(value, Side2, Side3):
                        Side1 = value;
                        break;
                    case 2 when IfTriangle(Side1, value, Side3):
                        Side2 = value;
                        break;
                    case 3 when IfTriangle(Side1, Side2, value):
                        Side3 = value;
                        break;
                    default:
                        Console.WriteLine("Incorrect number of side. There is only sides with numbers 1, 2 and 3");
                        break;
                }
            }

            public double ComputeAngle(int site1Number, int site2Number)
            {
                switch (site1Number)
                {
                    case 1 when site2Number == 2:
                    case 2 when site2Number == 1:
                        return Math.Acos((Side1 * Side1 + Side2 * Side2 - Side3 * Side3) / (2 * Side1 * Side2)) * 180 / Math.PI;
                    case 1 when site2Number == 3:
                    case 3 when site2Number == 1:
                        return Math.Acos((Side1 * Side1 + Side3 * Side3 - Side2 * Side2) / (2 * Side1 * Side3)) * 180 / Math.PI;
                    case 2 when site2Number == 3:
                    case 3 when site2Number == 2:
                        return Math.Acos((Side2 * Side2 + Side3 * Side3 - Side1 * Side1) / (2 * Side2 * Side3)) * 180 / Math.PI;
                    default:
                        Console.WriteLine("Incorrect number of side or equal sides: {0}, {1}. There is only sides with numbers 1, 2 and 3", site1Number, site2Number);
                        return 0;
                }
            }

            public double ComputePerimeter()
            {
                return Side1 + Side2 + Side3;
            }
            
            
            public static double Side1 { get; set; }
            public static double Side2 { get; set; }
            public static double Side3 { get; set; }

        }
        
        static void Main()
        {
            Triangle triangle1 = new Triangle(10, 20, 25);
            Console.WriteLine("Angle 1 2 = {0}, Angle 2 3 = {1}, Perimeter = {2}", triangle1.ComputeAngle(1, 2),
                triangle1.ComputeAngle(2, 3),
                triangle1.ComputePerimeter());
            
            triangle1.ChangeSide(23, 2);
            Console.WriteLine("Angle 1 2 = {0}, Angle 2 3 = {1}, Perimeter = {2}", triangle1.ComputeAngle(1, 2),
                triangle1.ComputeAngle(2, 3),
                triangle1.ComputePerimeter());
            
            EquilateralTriangle etriengleTriangle = new EquilateralTriangle(10);
            Console.WriteLine("Angle 1 2 = {0}, Angle 2 3 = {1}, Perimeter = {2}, Area = {3}",
                etriengleTriangle.ComputeAngle(1, 2),
                etriengleTriangle.ComputeAngle(2, 3),
                etriengleTriangle.ComputePerimeter(),
                etriengleTriangle.Area);
        } 
    }
}
