using System;

namespace InterfacesFinalTask
{
    public class LoggerDI : ILogger
    {
        void ILogger.Error(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
        }

        void ILogger.Event(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
        }
    }

    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }
}
