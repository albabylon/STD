using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        // объявим потокобезопасную очередь (полностью идентична обычной очереди, но
        // позволяет безопасный доступ
        // из разных потоков)
        public static ConcurrentQueue<string> words = new ConcurrentQueue<string>();

        static void Main(string[] args)
        {
            // Коллекции — это типы данных, разработанные для хранения последовательностей элементов

            // Условно все коллекции делятся на:
            // Обобщенные (System.Collections.Generic)
            // Необобщенные типизированные (System.Collections)
            // Для решения задач параллельного и многопоточного доступа используют коллекции из пространства имён System.Collections.Concurrent

            // Разница между необобщенными и обобщенными коллекциями стоит в том, что первые хранят данные разных типов, а вторые — одного.
            // Сохраняем предложение в строку

            // Потокобезопасная очередь
            Console.WriteLine("Введите слово и нажмите Enter, чтобы добавить его в очередь.");
            Console.WriteLine();

            //  запустим обработку очереди в отдельном потоке
            StartQueueProcessing();

            while (true)
            {
                var input = Console.ReadLine();

                // если введена нужная нам команда - смотрим, кто крайний в очереди
                if (input == "peek")
                {
                    if (words.TryPeek(out var elem))
                        Console.WriteLine(elem);
                }
                else
                {
                    // если не введена - ставим элемент в очередь, как и обычно
                    words.Enqueue(input);
                }
            }
        }

        // метод, который обрабатывает и разбирает нашу очередь в отдельном потоке
        // (для выполнения задания изменять его не нужно)
        static void StartQueueProcessing()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                while (true)
                {
                    Thread.Sleep(5000);
                    if (words.TryDequeue(out var element))
                        Console.WriteLine("======>  " + element + " прошел очередь");
                }

            }).Start();
        }
    }
}
