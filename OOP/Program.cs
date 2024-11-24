using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ObjClass obj1 = new ObjClass() { Str = "Value1", Intgr = 1, Rectangle = new Rectangle() { a = 1, b = 1 } };
            ObjClass obj2 = obj1;

            obj1.Str = "Value2";
            obj1.Intgr = 2;
            obj1.Rectangle = new Rectangle() { a = 2, b = 2 };

            ObjStruct objStr1 = new ObjStruct() { Str = "Value1", Intgr = 1, Rectangle = new Rectangle() { a = 1, b = 1 } };
            ObjStruct objStr2 = objStr1;

            objStr1.Str = "Value2";
            objStr1.Intgr = 2;
            objStr1.Rectangle = new Rectangle() { a = 2, b = 2 };
        }

        class ObjClass
        {
            public string Str;
            public int Intgr;
            public Rectangle Rectangle;
        }
        struct ObjStruct
        {
            public string Str;
            public int Intgr;
            public Rectangle Rectangle;
        }

        class Rectangle
        {
            public double a;
            public double b;

            public Rectangle()
            {
                a = 6;
                b = 4;
            }

            public Rectangle(double a)
            {
                a = this.a;
                b = a;
            }

            public Rectangle(double a, double b)
            {
                a = this.a;
                b = this.b;
            }

            double Square (double a, double b)
            {
                return a * b;
            }
        }
    }
}
