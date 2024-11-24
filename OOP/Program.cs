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
            //отличе класс от структуры
            //ObjClass obj1 = new ObjClass() { Str = "Value1", Intgr = 1, Rectangle = new Rectangle() { a = 1, b = 1 } };
            //ObjClass obj2 = obj1;

            //obj1.Str = "Value2";
            //obj1.Intgr = 2;
            //obj1.Rectangle = new Rectangle() { a = 2, b = 2 };

            //ObjStruct objStr1 = new ObjStruct() { Str = "Value1", Intgr = 1, Rectangle = new Rectangle() { a = 1, b = 1 } };
            //ObjStruct objStr2 = objStr1;

            //objStr1.Str = "Value2";
            //objStr1.Intgr = 2;
            //objStr1.Rectangle = new Rectangle() { a = 2, b = 2 };

            //проверка на нулл
            var department = GetCurrentDepartment();

            if (department.Company.Type == "Банк" && department.City.Name == "Санкт-Петербург")
            {
                string copmName = department?.Company?.Name ?? "Неизвестная компания";

                Console.WriteLine($"У банка {copmName} есть отделение в Санкт-Петербурге");
            }
        }

        class Bus
        {
            public int? Load;

            public void PrintStatus()
            {
                if (Load.HasValue && Load > 0)
                    Console.WriteLine("Количество пассажиров в автобусе: {0}", Load);
                else
                    Console.WriteLine("Автобус пустой!");
            }
        }

        static Department GetCurrentDepartment()
        {
            // logic
            return new Department();
        }
        class Company
        {
            public string Type;
            public string Name;
        }
        class Department
        {
            public Company Company;
            public City City;
        }
        class City
        {
            public string Name;
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
