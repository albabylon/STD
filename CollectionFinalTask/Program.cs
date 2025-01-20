using System;
using System.IO;
using System.Net;
using System.Text;

namespace CollectionFinalTask
{
    internal class Program
    {
        private const string path = "https://drive.google.com/uc?export=download&id=1jg43arS4KIUwO0-kao_ga7PWIPWBOXxo";
        private const string fileName = "input.txt";

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            if (!CheckFileExist())
            {
                DowmloadFile();
            }
            else
                Console.WriteLine("Файл уже был скачан");
            string text = ReadFile() ?? throw new Exception("Пустая переменная с текстом");
            Console.ResetColor();

            Splitter();
            // Задание 13.6.1 - Сравнение времени добавления в середину списка для List и LinkedList
            ListLinkedListComparer listLinkedListComparer = new ListLinkedListComparer(text);
            listLinkedListComparer.CompareCharInsertingTime('$', "ЧЕМ ДЛИНЕЕ ТЕКСТ ТЕМ ЭФФЕКТИВНЕЕ РАБОТА LINKEDLIST");

            Splitter();
            // Задание 13.6.2 - Какие 10 слов чаще всего встречаются в тексте
            RepeatedWordsDetector repeatedWordsDetector = new RepeatedWordsDetector(text);
            repeatedWordsDetector.GetUniqWords();
            repeatedWordsDetector.Show();
            Console.ReadLine();
        }

        private static void DowmloadFile()
        {
            Console.WriteLine("Начато скачивание файла...");
            // Path.Combine код будет работать на любой ОС
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(path, fileName);
                }
            }
            catch (Exception ex) { Console.WriteLine($"Ошибка скачивания:\n{ex}"); }

            Console.WriteLine("Cкачивание файла выполнено!");
        }
        private static bool CheckFileExist()
        {
            if (File.Exists(fileName))
                return true;
            return false;
        }
        private static string ReadFile()
        {
            StringBuilder sb = new StringBuilder();

            Console.WriteLine("Начато считывание файла...");
            // можно было использовать ReadAllLine
            using (StreamReader sr = File.OpenText(fileName))
            {
                while (sr.ReadLine() != null)
                {
                    sb.AppendLine(sr.ReadLine());
                }
            }

            Console.WriteLine("Cчитывание файла выполнено!");

            return sb.ToString();
        }
        private static void Splitter()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------");
        }
    }
}
