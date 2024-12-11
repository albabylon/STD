using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberReader reader = new NumberReader();
            reader.NumberEnteredEvent += ShowNumber;

            while (true)
            {
                try
                {
                    reader.Read();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void ShowNumber(int number)
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine("Введено число 1");
                    break;
                case 2:
                    Console.WriteLine("Введено число 2");
                    break;
            }
        }
    }

    public class NumberReader
    {
        public delegate void NumberEnteredDelegate(int value);
        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read() 
        {
            Console.WriteLine();
            Console.WriteLine("Введите число 1 или 2:");

            if (!int.TryParse(Console.ReadLine(), out int number)) 
            {
                if (number != 1 && number != 2)
                    throw new FormatException("Ошибка ввода данных");
            }

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int value)
        {
            NumberEnteredEvent?.Invoke(value);
        }
    }
}
