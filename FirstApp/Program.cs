using System;

namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Как тебя зовут?");
            string name = Console.ReadLine();
            
            Console.WriteLine("Сколько тебе лет?");
            int.TryParse(Console.ReadLine(), out int age);

            Console.WriteLine("Какая у тебя дата рождения?");
            string birthdate = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Имя: {0}\nЛет: {1}\nДата рождения: {2}", name, age, birthdate);

            Console.ReadKey();
        }
    }
}
