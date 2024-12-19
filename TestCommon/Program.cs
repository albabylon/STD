using System;
using System.Collections.Generic;

namespace TestCommon
{
    internal class Program
    {
        public static List<string> Error { get; set; } = new List<string>();

        static void Main(string[] args)
        {
            try
            {
                Method();
            }
            catch (Exception ex) 
            { 

            }

            Console.WriteLine(string.Join(", ", Error));

            Console.ReadLine();
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
