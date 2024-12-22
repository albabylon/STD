using System;

namespace InterfacesFinalTask
{
    public class Program
    {
        static ILogger logger {  get; set; }
        static void Main(string[] args)
        {
            logger = new LoggerDI();

            Calculate calculate = new Calculate(logger);
            calculate.Read();
            ((ISum)calculate).Sum();
            calculate.ShowResult();

            Console.Read();
        }
    }

}
