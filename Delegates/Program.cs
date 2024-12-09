using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            int y = 25;
            //Обычный делегат
            DifferenceDelegate difDelegate = Difference;

            //Добавление метода в делегат (Стал Мультикаст делегат)
            difDelegate += Sum;

            //Удаление метода из делегата
            difDelegate -= Sum;

            //Объединение делегат
            DifferenceDelegate difDelegate2 = Sum;
            DifferenceDelegate difDelefate3 = difDelegate + difDelegate2;

            difDelegate(x, y); //вариант вызова делегата 1
            difDelegate.Invoke(x, y); //вариант вызова делегата 2

            //Шаблонные делегаты: Func, Action, Predicate
            //Func - 16 входных, последний выходной параметр
            Func<int, int, int> Addition = AddNumbers;
            int result = Addition(10, 20);
            Console.WriteLine(result);

            //Action - от 0 до 16 входных и ничего не возращает
            Action<string> action = new Action<string>(Display);
            action("Привет разработчик!");

            //Predicate - принимает 1 параметр и возвращает true/false
            Predicate<string> CheckIfApple = IsApple;
            bool result3 = CheckIfApple("IPhone X"); 
            if (result3) 
                Console.WriteLine("Это IPhone X");

            //Можно использовать in и out, но передача не по ссылке


            //Анонимные методы - метод без имени, определяется delegate
            //Имеют доступ к переменным во внешней среде
            ShowMessageDelegate smDelegate = delegate (string _message)
            {
                Console.WriteLine(_message);
            };
            smDelegate("Hello");

            RandomNumberDelegate rnDelegate = delegate ()
            {
                return new Random().Next(0, 100);
            };
            int result4 = rnDelegate.Invoke();
            Console.WriteLine(result4);

            //Лямбда-выражения - сокращение для записи анонимного метода
            //Слева входные параметры, справа выражение с ними
            CalculateDelegate calculation = (x1, y1) => x1 - y1; //(x1, y1) => x1 - y1 - запись через ляюбду анонимного метода
            Console.WriteLine(calculation(10, 20));
            Console.WriteLine(calculation(40, 20));
            Console.Read();

            ShowMessageDelegate smDeleagate2 = (string _message) =>
            {
                Console.WriteLine(_message);
            };
            smDeleagate2("Hello");

            RandomNumberDelegate rnDelegate2 = () =>
            {
                return new Random().Next(0, 100);
            };
            int result42 = rnDelegate();

            Console.ReadLine();
        }

        delegate int CalculateDelegate(int x, int y);
        delegate int RandomNumberDelegate();
        delegate void ShowMessageDelegate(string _message);
        private static bool IsApple(string modelName)
        {
            if (modelName == "IPhone X") return true;
            else return false;
        }
        static void Display(string message)
        {
            Console.WriteLine(message);
        }
        private static int AddNumbers(int param1, int param2)
        {
            return param1 + param2;
        }
        public delegate void DifferenceDelegate (int x, int y);
        public delegate void SomeDelegate();
        public static void Difference (int x, int y)
        {
            Console.WriteLine(y - x);
        }
        public static void Sum(int x, int y)
        {
            Console.WriteLine(y + x);
        }
        public static void SomeMethod() { }
    }
}
