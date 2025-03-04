using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCommon
{
    internal class Program
    {
        public static List<string> Error { get; set; } = new List<string>();

        static void Main(string[] args)
        {
            //try
            //{
            //    Method();
            //}
            //catch (Exception ex) 
            //{ 

            //}

            //Console.WriteLine(string.Join(", ", Error));

            //var ms = new MyStruct(5);
            //using (ms)
            //{
            //    ms.Foo();
            //}
            //Console.WriteLine(ms.a);

            //int iterator = 0;
            //int[] array = { 1, 2, 3, 4, 5, 6 };
            //var flter = array.Where(n => n > 3).Select(_ => iterator++);
            //Console.WriteLine(flter.First());
            //Console.WriteLine(iterator);

            try
            {
                Action<string> action = new Action<string>(Console.WriteLine);
                AddMethod(action);
                action("Hello world");
            }
            catch 
            {
                Console.WriteLine("Error");
            }

            Console.ReadLine();
        }

        private static void AddMethod(Action<string> action)
        {
            action += Console.WriteLine;
            action += Console.WriteLine;
            action -= Console.WriteLine;
        }

        public struct MyStruct : IDisposable
        {
            public int a;
            public MyStruct(int a)
            {
                this.a = a;
            }

            public void Foo()
            {
                a = 7;
            }

            public void Dispose()
            {
                a = 0;
            }
        }

        private static void Method()
        {
            List<string> list = new List<string>() { "sasha", "masha", "dasha" };
            foreach (string l in list)
            {
                try
                {
                    throw new Exception(l);
                }
                catch (Exception e)
                {
                    Error.Add(l);
                }
            }
        }
    }
}
