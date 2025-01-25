using System.Linq;
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LINQ1
{
    internal class Program
    {
        //Select() осуществляет выборку объектов в новую сущность. Класс создавать необязательно, выборка возможна в анонимную сущность.
        //Пример: есть база данных пользователей, вы делаете по ним отчёты.

        //Ключевое слово let эффективно сочетать с выборками через Select там, где нужна локальная переменная для выполнения промежуточных операций на ходу.

        //Множественная выборка нужна там, где необходимо соединить данные из нескольких источников.

        //Сочетание методов Skip() и Take() помогает управлять выборкой элементов, если необходимо их отображать постранично

        //SkipWhile() и TakeWhile() нужны для того, чтобы показывать элементы пока верно определенное условие.К примеру, в базе данных у вас есть большой список одинаковых сущностей, и вам нужно достать их все, но после них идут уже сущности с другим свойством, и их вы трогать не хотите. Вам подойдёт метод TakeWhile().
        static void Main(string[] args)
        {
            //Разновидность LINQ
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

            Method3();

            Method6();
        }

        // ФИЛЬТРАЦИЯ
        // SelectMany()
        public static void Method()
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

        // ПРОЕКЦИЯ И ВЫБОРКА
        // Select()

        // Переменные в запросах, let
        public static void Method1()
        {
            var students = new List<Student>();

            var fullNameStudents = from s in students
                                       // временная переменная для генерации полного имени
                                   let fullName = s.Name + " Иванов"
                                   // проекция в новую сущность с использованием новой переменной
                                   select new
                                   {
                                       Name = fullName,
                                       Age = s.Age
                                   };

            foreach (var stud in fullNameStudents)
                Console.WriteLine(stud.Name + ", " + stud.Age);
        }
        public static void Method2()
        {
            List<Student> students = new List<Student>
            {
               new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
               new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
               new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
               new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var result = students
                .Where(st => st.Age < 27)
                .Select(st => new Application() { Name = st.Name, YearOfBirth = DateTime.Now.Year - st.Age });
        }

        // Множественная выборка
        public static void Method3()
        {
            // Список студентов
            var students = new List<Student>
            {
               new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
               new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
               new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }}
            };

            // Список курсов
            var coarses = new List<Coarse>
            {
               new Coarse {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
               new Coarse {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
            };

            // добавим студентов в курсы
            var studentsWithCoarses = from stud in students
                                      from coarse in coarses
                                      select new { Name = stud.Name, CoarseName = coarse.Name };

            // выведем результат
            foreach (var stud in studentsWithCoarses)
                Console.WriteLine($"Студент {stud.Name} добавлен курс {stud.CoarseName}");
        }
        public static void Method4()
        {
            // Список студентов
            var students = new List<Student>
            {
               new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
               new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
               new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }}
            };

            // Список курсов
            var coarses = new List<Coarse>
            {
               new Coarse {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
               new Coarse {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
            };

            // добавим студентов в курсы
            var studentsWithCoarses = from st in students
                                      where st.Age < 29 && st.Languages.Any(l => l == "английский")
                                      let birthYear = DateTime.Now.Year - st.Age
                                      from coarse in coarses
                                      where coarse.Name == "Язык программирования C#"
                                      select new { Name = st.Name, BirthYear = birthYear, CoarseName = coarse.Name };


            // выведем результат
            foreach (var stud in studentsWithCoarses)
                Console.WriteLine($"Студент {stud.Name} ({stud.BirthYear}) добавлен курс {stud.CoarseName}");
        }

        // Skip(), Take()
        public static void Method5()
        {
            var cars = new[] { "Volvo", "Opel", "Suzuki", "Toyota", "Lada", "Kamaz" };

            // пропустим первые два элемента
            var skip2 = cars.Skip(2);

            foreach (var car in skip2)
                Console.WriteLine(car);

            // ИЛИ
            // пропустим первые два элемента и выведем следующие два
            var skip3 = cars.Skip(2).Take(2);

            foreach (var car in skip3)
                Console.WriteLine(car);

            // Особенно удобно эти методы применять вместе для создания постраничного вывода. 
            // К примеру, на первой странице вы показываете товары с 1 по 10, то есть в данном случае условный код будет выглядеть вот так:
            // var page1 = products.Take(10);
            // Далее, на второй и третьей странице:
            // var page2 = products.Skip(10).Take(10)
            // var page3 = products.Skip(20).Take(10)
        }
        public static void Method6()
        {
            var contacts = new List<Contact>()
            {
               new Contact() { Name = "Андрей", Phone = 7999945005 },
               new Contact() { Name = "Сергей", Phone = 799990455 },
               new Contact() { Name = "Иван", Phone = 79999675 },
               new Contact() { Name = "Игорь", Phone = 8884994 },
               new Contact() { Name = "Анна", Phone = 665565656 },
               new Contact() { Name = "Василий", Phone = 3434 }
            };

            // бесконечный цикл, ожидающий ввод с консоли
            while (true)
            {
                var keyChar = Console.ReadKey().KeyChar; // получаем символ с консоли
                Console.Clear();  //  очистка консоли от введенного текста

                if (!Char.IsDigit(keyChar))
                    Console.WriteLine("Ошибка ввода, введите число");

                //  переменная для хранения запроса в зависимости от введенного с консоли числа
                IEnumerable<Contact> page = null;

                switch (keyChar)
                {
                    case '1':
                        page = contacts.Take(2);
                        break;
                    case '2':
                        page = contacts.Skip(2).Take(2);
                        break;
                    case '3':
                        page = contacts.Skip(4).Take(2);
                        break;
                }

                //   проверим, что ввели существующий номер страницы
                if (page == null)
                {
                    Console.WriteLine($"Ошибка ввода, страницы {keyChar} не существует");
                    continue;
                }

                // вывод результата на консоль
                foreach (var contact in page)
                    Console.WriteLine(contact.Name + " " + contact.Phone);
            }
        }

        // SkipWhile(), TakeWhile() - прерывается как только встретит неудовлятворящий условию элемент
        public static void Method7()
        {
            // Подготовка данных
            var cars = new List<Car>()
            {
               new Car("Suzuki", "JP"),
               new Car("Toyota", "JP"),
               new Car("Opel", "DE"),
               new Car("Kamaz", "RUS"),
               new Car("Lada", "RUS"),
               new Car("Lada", "RUS"),
               new Car("Honda", "JP"),
            };

            Console.WriteLine("Пропустим японские машины в начале списка");
            var notJapanCars = cars.SkipWhile(car => car.CountryCode == "JP");

            foreach (var notJapanCar in notJapanCars)
                Console.WriteLine(notJapanCar.Manufacturer);

            Console.WriteLine();

            Console.WriteLine("Теперь выберем только японские машины из начала списка");
            var japanCars = cars.TakeWhile(car => car.CountryCode == "JP");

            foreach (var japanCar in japanCars)
                Console.WriteLine(japanCar.Manufacturer);

            // При последовательном прохождении элементов метод SkipWhile() пропустил только первые два, удовлетворяющие критерию car.CountryCode == "JP".
            // Дальше он встретил первый элемент, не удовлетворяющий условию, и поток выполнения вышел из цикла пропуска элементов.
            // Все последующие элементы в выборку попадут. Поэтому мы и видим в конце элемент, которого на первый взгляд там быть не должно.
        }

        // СОРТИРОВКА
        // OrderBy(),OrderByDescending() - Простая сортировка

        // OrderBy(), OrderByDescending(), ThenBy() Множественная сортировка
        public static void Method8()
        {
            // Список студентов
            var students = new List<Student>
            {
               new Student {Name="Алёна", Age=23, Languages = new List<string> {"английский", "немецкий" }},
               new Student {Name="Яков", Age=23, Languages = new List<string> {"английский", "немецкий" }},
               new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
               new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
               new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
               new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            // Сортировка сначала по имени, а затем - по возрасту
            var sortedStuds1 = from s in students orderby s.Name, s.Age select s;

            foreach (var stud in sortedStuds1)
                Console.WriteLine(stud.Name + ", " + stud.Age);

            // Сортировка по имени и возрасту (возрастание)
            var sortedStuds2 = students
               .OrderBy(s => s.Name)
               .ThenBy(s => s.Age);

            foreach (var stud in sortedStuds2)
                Console.WriteLine(stud.Name + ", " + stud.Age);
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
    }

    public class Application
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
    }

    public class Coarse
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
    }
    
    public class Contact
    {
        public string Name { get; set; }
        public long Phone { get; set; }
    }

    public class Car
    {
        public string Manufacturer { get; set; }
        public string CountryCode { get; set; }

        public Car(string manufacturer, string countryCode)
        {
            Manufacturer = manufacturer;
            CountryCode = countryCode;
        }
    }
}
