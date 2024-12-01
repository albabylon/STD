using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public static class IntrospectionExtensions
    {
        public static int GetNegative(this int a)
        {
            if (a >= 0)
                return -a;
            else
                return a;
        }

        public static int GetPositive(this int a)
        {
            if (a >= 0)
                return a;
            else
                return -a;
        }
    }

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
            //var department = GetCurrentDepartment();

            //if (department.Company.Type == "Банк" && department.City.Name == "Санкт-Петербург")
            //{
            //    string copmName = department?.Company?.Name ?? "Неизвестная компания";

            //    Console.WriteLine($"У банка {copmName} есть отделение в Санкт-Петербурге");
            //}

            //BaseClass baseClass = new BaseClass("name");
            ////baseClass.Display();
            //DerivedClass derivedClass = new DerivedClass("name", "description");
            //derivedClass.Display();

            //D d = new D();
            //E e = new E();

            //d.Display();
            //((A)e).Display();
            //((B)d).Display();
            //((A)d).Display();

            //int[] arrayNumbers = new int[] { 23, 32, 54, 44, 00 };

            //IndexingClass indexingClass = new IndexingClass(arrayNumbers);

            //Console.WriteLine(indexingClass[3]);

            //int num1 = 3_000_333;
            //int num2 = 58;

            //Helper.Swap(ref num1, ref num2);

            //string s = "dsada";


            //Console.WriteLine(num1); //58
            //Console.WriteLine(num2); //3

            int num1 = 7;
            int num2 = -13;
            int num3 = 0;

            Console.WriteLine(num1.GetNegative()); //-7
            Console.WriteLine(num1.GetPositive()); //7
            Console.WriteLine(num2.GetNegative()); //-13
            Console.WriteLine(num2.GetPositive()); //13
            Console.WriteLine(num3.GetNegative()); //0
            Console.WriteLine(num3.GetPositive()); //0

            Console.ReadKey();
        }


        public class Helper 
        {
            public static void Swap (ref int a, ref int b)
            {
                int c = a;
                a = b;
                b = c;
            }
        }


        public class Objec
        {
            public string Name;
            public string Description;
            public static int MaxValue = 2000;
        }

        public abstract class ComputerPart
        {
            public abstract void Work();
        }
        class Processor : ComputerPart
        {
            public override void Work()
            {
                throw new NotImplementedException();
            }
        }
        class MotherBoard : ComputerPart
        {
            public override void Work()
            {
                throw new NotImplementedException();
            }
        }
        class GraphicCard : ComputerPart
        {
            public override void Work()
            {
                throw new NotImplementedException();
            }
        }



        class IndexingClass
        {
            private int[] array;

            public IndexingClass(int[] array)
            {
                this.array = array;
            }

            public int this[int i]
            {
                get
                {
                    if (i >= 0 && i < array.Length)
                        return array[i];
                    else
                        return 0;
                }
                set
                {
                    if (i >= 0 && i < array.Length)
                    {
                        this[i] = value;
                    }
                }
            }
        }


        class Obje
        {
            public int Value;

            public static Obje operator + (Obje a, Obje b)
            {
                Obje obje = new Obje();
                obje.Value = a.Value + b.Value;

                return obje;
            }
            public static Obje operator - (Obje a, Obje b)
            {
                Obje obje = new Obje();
                obje.Value = a.Value - b.Value;

                return obje;
            }
        }


        class A
        {
            public virtual void Display()
            {
                Console.WriteLine("Метод класса A");
            }
        }
        class B : A
        {
            public new void Display()
            {
                Console.WriteLine("Метод класса B");
            }
        }
        class C : A
        {
            public override void Display()
            {
                Console.WriteLine("Метод класса C");
            }
        }
        class D : B
        {
            public new void Display()
            {
                Console.WriteLine("Метод класса D");
            }
        }
        class E : C
        {
            public new void Display()
            {
                Console.WriteLine("Метод класса E");
            }
        }



        class BaseClass
        {
            protected string Name;

            public BaseClass(string name)
            {
                Name = name;
            }

            public virtual int Counter
            {
                get;
                set;
            }

            public virtual void Display() 
            {
                Console.WriteLine("Метод класса BaseClass");
            }
        }

        class DerivedClass : BaseClass
        {
            public string Description;

            private int counter;
            public override int Counter 
            {
                get
                {
                    return counter;
                }
                set
                {
                    if (value < 0)
                        value = 0;
                    else
                        counter = value;
                }
            }

            public DerivedClass(string Name, string Description) : base(Name)
            {
                this.Description = Description;
            }

            public DerivedClass(string Name, string Description, int counter) : this(Name, Description)
            {
                Counter = counter;
            }

            public override void Display()
            {
                base.Display();
                Console.WriteLine("Метод класса DerivedClass");
            }
        }



        class Obj
        {
            private string name;
            private string owner;
            private int length;
            private int count;

            public Obj(string name, string ownerName, int objLength, int count)
            {
                this.name = name;
                owner = ownerName;
                length = objLength;
                this.count = count;
            }
        }
        class Employee
        {
            public string Name;
            public int Age;
            public int Salary;
        }

        class ProjectManager : Employee
        {
            public string ProjectName;
        }

        class Developer : Employee
        {
            public string ProgrammingLanguage;
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
