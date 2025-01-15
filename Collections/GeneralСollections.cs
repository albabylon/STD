using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class GeneralСollections
    {
        // Обобщенные коллекции оптимально решают задачи хранения и операций с объектами одного типа (System.Collections.Generic.)

        // LIST
        // Класс List<T> представляет собой динамический массив объектов, а значит, он автоматически изменяет свой объём при добавлении и удалении новых.
        // Для этого он предоставляет методы Add() и Remove() соответственно.

        private void MethodList()
        {
            List<string> strings = new List<string>();

            strings.AddRange(new List<string>() { "dad", "dsada"}); // добавятся в конец списка
            strings.Sort();
            strings.BinarySearch("dad"); // ищет только в отсортированном списке
        }

        private static void AddUnique(Contact newContact, List<Contact> phoneBook)
        {
            bool alreadyExists = false;

            // пробегаемся по списку и смотрим, есть ли уже с таким именем
            foreach (var contact in phoneBook)
            {
                if (contact.Name == newContact.Name)
                {
                    //  если вдруг находим  -  выставляем флаг и прерываем цикл
                    alreadyExists = true;
                    break;
                }
            }

            if (!alreadyExists)
                phoneBook.Add(newContact);

            //  сортируем список по имени
            phoneBook.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));

            foreach (var contact in phoneBook)
                Console.WriteLine(contact.Name + ": " + contact.PhoneNumber);
        }
        private class Contact { public string Name { get; set; } public long PhoneNumber { get; set; } }

        private void GetMissing1(List<string> monthes, ArrayList missing)
        {
            foreach (var mis in missing)
            {
                if (mis is string misStr)
                    monthes.Add(misStr);
            }
        }
        private static void GetMissing2(List<string> months, ArrayList missing)
        {
            // инициализируем массив для 7 нужных нам недостающих элементов
            var missedArray = new string[7];

            // извлекаем эти элементы из ArrayList, и копируем в массив
            missing.GetRange(4, 7).CopyTo(missedArray);

            // Добавляем наш массив в конец списка
            months.AddRange(missedArray);

            // смотрим, что получилось
            foreach (var month in months)
                Console.WriteLine(month);
        }


        // HASHSET (SORTEDSET) : ISET<T>
        // Коллекция, содержащая не повторяющиеся (уникальные) элементы, иначе называется множеством (set).
        // В .NET для этого имеются типы данных  HashSet<T> и SortedSet<T>. Оба они реализуют интерфейс ISet<T>. 

        // Класс HashSet<T> поддерживает сохранение неупорядоченного списка уникальных элементов.
        // Во всех случаях, когда вам нужна уникальность, но не важна упорядоченность элементов, с точки зрения производительности оптимально использовать именно его.
        private void MethodHashSet()
        {
            string[] names =  
            {
               "Игорь",   // повторяющееся значение
               "Андрей",
               "Васиий",
               "София",
               "Елена",
               "Анна",
               "Игорь"  //  повторяющееся значение
            };

            // Создаем хэш - сет, передавая в конструктор наш массив
            HashSet<string> hSet = new HashSet<string>(names);
            // В результате повторяющиеся значения схлопнуться

            // UnionWith() - Объединяет
            // ExceptWith(otherCollection) - Удаляет из хэш-сета все элементы, содержащиеся в другой коллекции
            // SymmetricExceptWith(otherCollection)  - Специфичный метод. Изменяет HashSet<T> таким образом, чтобы он содержал только те элементы, которые есть в нём самом или otherCollection, исключая дубликаты на уровне обеих коллекций.
        }

        // DICTIONARY <TKey, TValue>
        // Словарь — ещё один очень распространённый тип коллекций. Он хранит объекты, которые представляют пару ключ-значение, то есть, обращаясь по ключу, мы можем получить значение.
        // Соответственно, каждое значение словаря в отдельности является структурой KeyValuePair<TKey, TValue>.
        private void MethodDictionary()
        {
            // Создадим словарь. Ключом будет строка, а значением - массив строк
            var cities = new Dictionary<string, string[]>(3 /* Размер (указывать необязательно))*/ );

            // Добавим новые значения
            cities.Add("Россия", new[] { "Москва", "Санкт-Петербург", "Волгоград" });
            cities.Add("Украина", new[] { "Киев", "Львов", "Николаев", "Одесса" });
            cities.Add("Беларусь", new[] { "Минск", "Витебск", "Гродно" });
            //  Посмотрим всё что есть в словаре
            foreach (var citiesByCountry in cities)
            {
                Console.Write(citiesByCountry.Key + ": ");
                foreach (var city in citiesByCountry.Value)
                    Console.Write(city + " ");

                Console.WriteLine();
            }

            Console.WriteLine();

            // Теперь попробуем вывести значения по ключу
            var russianCities = cities["Россия"];
            Console.WriteLine("Города России:");
            foreach (var city in russianCities)
                Console.WriteLine(city);

            // изменение объекта
            cities["Россия"] = new[] { "Мурманск", "Казань" };

            // удаление по ключу
            cities.Remove("Беларусь");

            // TryAdd() - если ключь есть, то будет false и элемент не добавится
            // ContainsValue() ContainsKey() - проверка наличия знаения/ключа
        }

        // SORTEDDICTIONARY <TKey, TValue>
        // По сути эта структура данных аналогична словарю, но элементы в ней сортируются по значению ключа.
        // Здесь стоит принять во внимание, что в плане производительности сортированный словарь будет медленнее обычного,
        // но когда речь не идёт об очень больших объёмах данных и нужна сортировка по умолчанию, он может стать оптимальным решением.

        // STACK<T>
        // В общем смысле стек — это абстрактный тип данных, позволяющий сохранить элементы в список  по принципу Last In — First Out (LIFO),
        // то есть последний сохраненный элемент будет обработан первым.
        private void MethodStack()
        {
            var stack = new Stack<string>();

            stack.Push("FirstWord"); // добавить в стэк
            stack.Push("LastWord");

            var element = stack.Pop(); // извлекает и удаляет последний добавленный

            var element1 = stack.Peek(); // просмотр в стэеке без удаления последнего элемента

            // Есть еще TryPop() TryPeek()
        }

        // QUEUE  и QUEUE<T>
        // Очередь (queue) — это коллекция, в которой элементы обрабатываются по схеме «первый вошел, первый вышел» (First In, First Out — FIFO).
        // Очень часто бывают ситуации, когда программа генерирует  поток данных быстрее, чем его возможно обработать. Для этих целей и были созданы очереди, у них есть очень разные реализации. 

        // Enqueue() — добавляет элемент в конец очереди.
        // Dequeue() — извлекает и возвращает первый элемент очереди.
        // Peek() - просмотр крайнего элемента очереди
        private void MethodQueue()
        {
            {
                // создаем очередь
                Queue<int> q = new Queue<int>();

                // добавляем в нее целые числа от 0 до 10
                for (int i = 0; i <= 10; i++)
                {
                    q.Enqueue(i);
                    Console.WriteLine($"{i} зашёл в очередь");
                }

                // Посмотрим, кто первый в очереди
                Console.WriteLine($"Первый элемент:   {q.Peek()}");

                // Обратите внимание, после  вызова Peek() элемент остается в очереди

                //  Посмотрим всю очередь
                Console.WriteLine("Элементы в очереди");
                foreach (int i in q)
                    Console.Write(i + " ");

                Console.WriteLine();
                Console.WriteLine($"В очереди  {q.Count} элементов");
                // обработаем очередь -
                // достанем из неё элементы один за другим
                var queueLength = q.Count;
                for (int i = 0; i < queueLength; i++)
                    Console.WriteLine($"{q.Dequeue()} вышел из очереди");
                //  Посмотрим, сколько элементов осталось
                Console.WriteLine($"В очереди  {q.Count} элементов");
            }
        }

        // LINKEDLIST<T>
        // В этой коллекции каждый элемент списка имеет ссылки на следующий и предыдущий
        // Основное преимущество этого типа данных — очень высокая скорость вставки элемента в середину списка
        // Все их элементы доступны лишь друг за другом. Поэтому при большом размере списка нахождение элемента из середины или конца занимает достаточно много времени. 
        // LinkedList<T> не просто хранит информацию об элементе внутри себя, вместе с этим ему также необходимо хранить информацию о предыдущем или последующем элементе
        // Каждый из элементов связного списка имеет тип LinkedListNode<T> и предоставляет свойства для доступа к следующему и предыдущему элементам
        public static void MethodLinkList(LinkedList<string> linkedList)
        {
            // Добавим несколько элементов
            linkedList.AddFirst("Лиса");
            linkedList.AddFirst("Волк");
            linkedList.AddFirst("Заяц");
            var mouse = linkedList.AddFirst("Мышь");

            GoOnwards(linkedList); //   Прямой проход списка
            GoBackwards(linkedList); // Обратный проход списка

            // Вставка нового элемента
            linkedList.AddAfter(mouse, "Медведь");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Выведем список ещё раз после вставки");
            Console.WriteLine();


            GoOnwards(linkedList); //   Прямой проход списка
            GoBackwards(linkedList); // Обратный проход списка
        }
        static void GoOnwards(LinkedList<string> linkedList)
        {
            LinkedListNode<string> node;

            Console.WriteLine("Элементы коллекции в прямом направлении: ");
            for (node = linkedList.First; node != null; node = node.Next)
                Console.Write(node.Value + " ");
        }
        static void GoBackwards(LinkedList<string> linkedList)
        {
            LinkedListNode<string> node;

            Console.WriteLine("\n\nЭлементы коллекции в обратном направлении: ");
            for (node = linkedList.Last; node != null; node = node.Previous)
                Console.Write(node.Value + " ");
        }
    }
}
