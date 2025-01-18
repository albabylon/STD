using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CollectionFinalTask
{
    public class ListLinkedListComparer
    {
        public List<char> charsByList;
        public LinkedList<char> charsByLinkedList;

        public ListLinkedListComparer()
        {
            charsByList = new List<char>();
            charsByLinkedList = new LinkedList<char>();
        }

        public ListLinkedListComparer(string text) : this()
        {
            AddingCharToList(text, charsByList);
            AddingCharToList(text, charsByLinkedList);
        }

        public void CompareCharInsertingTime(char testChar, string testString)
        {
            Console.WriteLine();
            Console.WriteLine("СРАВНЕНИЕ ВРЕМЕНИ ДОБАВЛЕНИЯ В --LIST-- И --LINKEDLIST-- В СЕРЕДИНУ 1 СИМВОЛА и МАССИВА СИМВОЛОВ (ТЕКСТА)");

            // List
            Stopwatch stopwatch = Stopwatch.StartNew();
            charsByList.Insert(charsByList.Count / 2, testChar);
            string timeCharsByList = stopwatch.Elapsed.TotalMilliseconds.ToString();

            stopwatch.Restart();
            charsByList.InsertRange(charsByList.Count / 2, testString);
            string timeStringByList = stopwatch.Elapsed.TotalMilliseconds.ToString();



            // поиск серединного нода, пропускаем в подсчете времени, так как учитываем только вставку
            char middleChar = charsByLinkedList.ElementAt(charsByLinkedList.Count / 2);
            var middleNode = charsByLinkedList.Find(middleChar);



            // LinkedList
            stopwatch.Restart();
            charsByLinkedList.AddAfter(middleNode, testChar);
            string timeCharsByLinkedList = stopwatch.Elapsed.TotalMilliseconds.ToString();

            stopwatch.Restart();
            foreach (char c in testString) 
            {
                charsByLinkedList.AddAfter(middleNode, c);
                middleNode = middleNode.Next;
            }
            string timeStringByLinkedList = stopwatch.Elapsed.TotalMilliseconds.ToString();

            Console.WriteLine();
            Console.WriteLine($"Добавление символа:");
            Console.WriteLine($"Время List: {timeCharsByList} мс");
            Console.WriteLine($"Время LinkedList: {timeCharsByLinkedList} мс");
            Console.WriteLine($"List быстрее добавляет в середину 1 элемент, LinkedList чем в {(int)(double.Parse(timeCharsByLinkedList) / double.Parse(timeCharsByList))} раз");

            Console.WriteLine();
            Console.WriteLine($"Добавление строки:");
            Console.WriteLine($"Время List: {timeStringByList} мс");
            Console.WriteLine($"Время LinkedList: {timeStringByLinkedList} мс");
            Console.WriteLine($"LinkedList быстрее добавляет в середину массив элементов, чем List в {(int)(double.Parse(timeStringByList) / double.Parse(timeStringByLinkedList))} раз");
        }
        
        private void AddingCharToList(string text, List<char> list)
        {
            foreach (char ch in text)
            {
                list.Add(ch);
            }
        }
        private void AddingCharToList(string text, LinkedList<char> list)
        {
            foreach (char ch in text)
            {
                list.AddFirst(ch);
            }
        }
    }
}
