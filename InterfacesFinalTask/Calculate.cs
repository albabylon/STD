using System;
using System.Threading;

namespace InterfacesFinalTask
{
    public class Calculate : ISum
    {
        private ILogger logger { get; }
        private double firstNumber { get; set; }
        private double secondNumber { get; set; }
        public double SumResult {  get; private set; }

        public Calculate(ILogger logger)
        {
            this.logger = logger;
        }

        double ISum.Sum()
        {
            SumResult = firstNumber + secondNumber;
            return SumResult;
        }

        public void Read()
        {
            logger.Event("Введите первое число:");
            firstNumber = ToDouble(Console.ReadLine());

            logger.Event("Введите второе число:");
            secondNumber = ToDouble(Console.ReadLine());
        }

        public void ShowResult()
        {
            logger.Event($"Итог сложения: {SumResult}");
        }

        private double ToDouble(string value)
        {
            double result = 0;

            try
            {
                result = double.Parse(value);
            }
            catch (FormatException)
            {
                logger.Error($"Введено не числовое значение: \"{value}\". Программа будет закрыта");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            finally { };

            return result;
        }
    }

}
