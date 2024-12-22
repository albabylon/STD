using System;

namespace InterfacesDIExample
{
    internal class Program
    {
        static ILogger logger { get; set; }
        static void Main(string[] args)
        {
            logger = new Logger();
            var worker1 = new Worker1(logger);
            var worker2 = new Worker2(logger);
            var worker3 = new Worker3(logger);

            worker1.Work();
            worker2.Work();
            worker3.Work();

            Console.ReadLine();
        }

    }

    //DI - внедрены зависимости через интерфейсы
    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }
    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine(message);
        }

        public void Event(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IWorker
    {
        void Work();
    }
}
