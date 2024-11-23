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
        }

        class Rectangle
        {
            double a;
            double b;

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
