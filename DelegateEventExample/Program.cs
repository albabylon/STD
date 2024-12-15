using System;

namespace DelegateEventExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberReader reader = new NumberReader(); //вызывем издателя
            reader.NumberEnteredEvent += ShowNumber; //подписываемся на событие, то есть указываем что должно произойти когда дойдет до этого события

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
            //тут что-то происходит
            Console.WriteLine();
            Console.WriteLine("Введите число 1 или 2:");

            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                if (number != 1 && number != 2)
                    throw new FormatException("Ошибка ввода данных");
            }

            //тут указываем что должно произойти какое-то событие
            NumberEntered(number);
        }

        protected virtual void NumberEntered(int value)
        {
            //реализация события через делегат
            NumberEnteredEvent?.Invoke(value);
        }
    }
}
