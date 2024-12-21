using System;

namespace InterfacesFinalTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            Calculate calculate = new Calculate();
            calculate.Read();
            ((ISum)calculate).Sum();
            calculate.ShowResult();

            Console.Read();
        }
    }

    public class Calculate : ISum
    {
        private double firstNumber;
        private double secondNumber;
        public double SumResult {  get; private set; }

        double ISum.Sum()
        {
            SumResult = firstNumber + secondNumber;
            return SumResult;
        }

        public void Read()
        {
            Console.WriteLine("Введите первое число:");
            firstNumber = ToDouble(Console.ReadLine());

            Console.WriteLine("Введите второе число:");
            secondNumber = ToDouble(Console.ReadLine());
        }

        public void ShowResult()
        {
            Console.WriteLine("Итог сложения: {0}", SumResult);
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
                Console.WriteLine($"Введено не числовое значение: \"{value}\". Введите число");
                Read();
            }
            finally { };

            return result;
        }
    }

    public interface ISum
    {
        double Sum();
    }

}
