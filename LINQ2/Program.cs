using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ2
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        // ОПЕРАЦИИ С 2умя КОЛЛЕКЦИЯМИ
        // Except() - Разность
        // Исключает из одной коллекции то, что содержится в другой

        // Intersect() - Пересечение
        // Находит общие эдементы коллекци1

        // Union() - Объединение (=Concat().Distinct())
        // Объединяет две коллекции в одну -  в результате коллекция с элементами из первой и второй, но без повторений

        // Concat() - Объединение
        // Объединяет, но не исключает повторения

        // Distinct() - Удаление дубликатов

        // ОПЕРАЦИИ АГРЕГАЦИИ
        // Aggregate() - выполнение арифметического действия с элементами коллекции.
        static void Method1()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int result = numbers.Aggregate((x, y) => x - y);

            // вычислит 1-2-3-4-5 = -13
            Console.WriteLine(result);
        }
        static long Factorial(int number)
        {
            int[] numbers = new int[number];
            int i = 0;
            while (i < number)
            {
                numbers[i] = (i++);
            }

            long result = numbers.Aggregate((x, y) => x * y);
            return result;
        }

        // Count() - можно использовать, когда вы хотите не просто посчитать элементы, а  узнать, сколько из них удовлетворяют определенным критериям.
        static void Method2()
        {
            var students = new List<Student>() 
            { 
                new Student() { Age = 27 }, 
                new Student() { Age = 21} 
            };
            // получим тех, кто младше 25
            var youngStudentsAmount = students.Count(s => s.Age < 25);

            // тоже выведет 1
            Console.WriteLine(youngStudentsAmount);
        }

        // Sum() - сложение
        static void Method3()
        {
            // Список студентов
            var students = new List<Student>
            {
               new Student {Name="Андрей", Age=23 },
               new Student {Name="Сергей", Age=27 },
               new Student {Name="Дмитрий", Age=29 }
            };

            // сумма возрастов всех студентов
            var totalAge = students.Sum(s => s.Age);

            // Вернет 79
            Console.WriteLine(totalAge);
        }

        // Мax(), Min(), Average()
        static void Method4()
        {
            var students = new List<Student>
            {
               new Student {Name="Андрей", Age=23 },
               new Student {Name="Сергей", Age=27 },
               new Student {Name="Дмитрий", Age=29 }
            };

            // найдем возраст самого старого студента ( 29 )
            var oldest = students.Max(s => s.Age);

            // самого молодого ( 23 )
            var youngest = students.Min(s => s.Age);

            //  и средний возраст ( 26,3 )
            var average = students.Average(s => s.Age);
        }


        // ОПЕРАЦИИ ГРУППИРОВКИ
        // GroupBy()
        // Каждая группа представляет объект IGrouping<string, Car>, где string — тип ключа, а параметр Car — тип сгруппированных объектов.
        // Ключ каждой группы доступен через свойство Key.
        static void Method5()
        {
            var cars = new List<Car>()
            {
               new Car("Suzuki", "JP"),
               new Car("Toyota", "JP"),
               new Car("Opel", "DE"),
               new Car("Kamaz", "RUS"),
               new Car("Lada", "RUS"),
               new Car("Honda", "JP"),
            };

            var carsByCountry = cars
                   .GroupBy(car => car.CountryCode) // группируем по стране-производителю
                   .Select(group => new
                   { //  создаем новую сущность анонимного типа
                       Name = group.Key,
                       Amount = group.Count()
                   });

            var carsByCountry2 = from car in cars
                                 group car by car.CountryCode into grouping // выборка в локальную переменную для вложенного запроса
                                 select new
                                 {
                                     Name = grouping.Key,
                                     Count = grouping.Count(),
                                     Cars = from p in grouping select p //  выполним подзапрос, чтобы заполнить список машин внутри нашего нового типа
                                 };
            // через расширения
            carsByCountry2 = cars
                   .GroupBy(car => car.CountryCode)
                   .Select(g => new
                   {
                       Name = g.Key,
                       Count = g.Count(),
                       Cars = g.Select(c => c)
                   });

            // Выведем результат
            foreach (var group in carsByCountry2)
            {
                // Название группы и количество элементов
                Console.WriteLine($"{group.Name} : {group.Count} авто");

                foreach (Car car in group.Cars)
                    Console.WriteLine(car.Manufacturer);

                Console.WriteLine();
            }
        }

        static void Method6()
        {
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", 799900000013, "serg@gmail.com"));
            phoneBook.Add(new Contact("Иннокентий", 799900000013, "innokentii@example.com"));

            var groups = phoneBook.GroupBy(c => c.Email.Split('@').Last());

            foreach(var group in groups)
            {
                if (group.Key.Contains("example"))
                {
                    Console.WriteLine("Фейковые адреса: ");

                    foreach (var contact in group)
                        Console.WriteLine(contact.Name + " " + contact.Email);

                }
                else
                {
                    Console.WriteLine("Реальные адреса: ");
                    foreach (var contact in group)
                        Console.WriteLine(contact.Name + " " + contact.Email);
                }

                Console.WriteLine();
            }
        }




        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public class Contact
        {
            public string Name { get; set; }
            public long Phone { get; set; }
            public string Email { get; set; }
            public Contact(string name, long phone, string email)
            {
                Name = name;
                Phone = phone;
                Email = email;
            }
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
}
