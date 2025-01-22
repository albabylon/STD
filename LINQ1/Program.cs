using System.Linq;
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LINQ1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Разновидность LINQ
            //LINQ to Objects: применяется для работы с массивами и коллекциями;
            //LINQ to Entities: применяется для работы с базой данных через Entity Framework;
            //LINQ to SQL: используется как технология доступа к данным в MS SQL Server;
            //LINQ to XML: применяется при работе с файлами XML;
            //LINQ to DataSet: применяется при работе с объектом DataSet;
            //Parallel LINQ(PLINQ): используется для выполнения параллельных запросов.


            // LINQ TO OBJECTS

            string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян" };

            // LINQ выражение
            var selectedPeople = from p in people // промежуточная переменная p 
                                 where p.StartsWith("А") // фильтрация по условию
                                 orderby p // сортировка по возрастанию (дефолтная)
                                 select p; // выбираем объект и сохраняем в выборку

            // LINQ расширений
            selectedPeople = people.Where(p => p.StartsWith("А")).OrderBy(p => p);

            foreach (string s in selectedPeople)
                Console.WriteLine(s);
        }

        // Фильтрация
        // SelectMany()
        void Method()
        {
            // Подготовим данные
            List<Student> students = new List<Student>
            {
               new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
               new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
               new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
               new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            // Составим запрос ()
            var selectedStudents = students
                .SelectMany(
                   s => s.Languages, // коллекция, которую нужно преобразовать
                   (s, l) => new { Student = s, Lang = l }) // функция преобразования, применяющаяся к каждому элементу коллекции                 
               .Where(s => s.Lang == "английский" && s.Student.Age < 28) // дополнительные условия     
               .Select(s => s.Student); // указатель на объект выборки

            // Выведем результат
            foreach (Student student in selectedStudents)
                Console.WriteLine($"{student.Name} - {student.Age}");
        }
    }

    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
    }
}
