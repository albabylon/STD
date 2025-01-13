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


    }
}
