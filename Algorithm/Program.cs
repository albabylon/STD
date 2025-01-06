using System;
using System.Threading;

namespace Algorithm
{
    internal class Program
    {
        // Алгоритм — это некоторый набор шагов, выполнение которых приводит к какому-то определённому результату.
        // Блок-схема — это графическая модель, описывающая алгоритм, в котором отдельные шаги изображены в виде блоков различной формы, соединенных между собой линиями.

        // Линейный алгоритм — это набор команд (действий), выполняемых последовательно во времени друг за другом, согласно порядку их записи
        // Циклический алгоритм — это алгоритм, предусматривающий многократное повторение одного и того же действия (или действий) над исходными данными.
        // Алгоритм с ветвлением — это алгоритм, содержащий хотя бы одно условие, в результате проверки которого обеспечивается переход на один из двух возможных шагов.

        static void Main(string[] args)
        {
            User[] users = new User[] 
            { 
                new User() { Name = "Sasha", IsPremium = false, Login = "s1" }, 
                new User() { Name = "Petr", IsPremium = true, Login = "p1" },
                new User() { Name = "Valentina", IsPremium = false, Login = "v1" },
                new User() { Name = "Alex", IsPremium = true, Login = "a1" } 
            };

            foreach (var user in users) 
            {
                CheckPremium(user);
                Console.WriteLine("_______________");
            }

            Console.ReadLine();
        }

        private static void CheckPremium(User user)
        {
            if (!user.IsPremium)
                ShowAds();
            Greeting(user.Name);
        }

        private static void Greeting(string name)
        {
            Console.WriteLine($"Привет, {name}");
        }

        private static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }

        private class User
        {
            public string Login { get; set; }
            public string Name { get; set; }
            public bool IsPremium { get; set; }
        }
    }
}
