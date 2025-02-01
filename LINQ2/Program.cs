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
            // Отложенное выполнение - При отложенном выполнении выражение не будет выполнено, пока мы не обратимся к его результату в цикле или итерации

            // var youngStudents = from s in students where s.Age < 25 select s;
            // Cама переменная запроса — youngStudents — не выполняет никаких действий. Она просто хранит сам запрос.

            // Стадии выполнения LINQ-запроса можно условно разделить так:
            // 1 Получение источника данных(инициализация коллекции, в нашем случае списка студентов).
            // 2 Создание запроса(определение переменной youngStudents).
            // 3 Выполнение и получение результата(при обращении к переменной в цикле).

            // Немедленное выполнение - методы, которые возвращают из коллекции один элемент или одно какое-либо значение ИЛИ сохранить результат выборки в новую коллекцию

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
        public static void Method1()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int result = numbers.Aggregate((x, y) => x - y);

            // вычислит 1-2-3-4-5 = -13
            Console.WriteLine(result);
        }
        public static long Factorial(int number)
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
        public static void Method2()
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
        public static void Method3()
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
        public static void Method4()
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
        public static void Method5()
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

        public static void Method6()
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


        // ОПЕРАЦИИ СОЕДИНЕНИЯ
        // позволяет объединить разные наборы объектов в коллекциях по общим свойствам
        // Join() - эту операцию можно применять к двум наборам коллекций, имеющим общий критерий
        public static void Method7()
        {
            // Список моделей
            var cars = new List<Car>()
            {
               new Car() { Model  = "SX4", Manufacturer = "Suzuki"},
               new Car() { Model  = "Grand Vitara", Manufacturer = "Suzuki"},
               new Car() { Model  = "Jimny", Manufacturer = "Suzuki"},
               new Car() { Model  = "Land Cruiser Prado", Manufacturer = "Toyota"},
               new Car() { Model  = "Camry", Manufacturer = "Toyota"},
               new Car() { Model  = "Polo", Manufacturer = "Volkswagen"},
               new Car() { Model  = "Passat", Manufacturer = "Volkswagen"},
            };

            // Список автопроизводителей
            var manufacturers = new List<Manufacturer>()
            {
               new Manufacturer() { Country = "Japan", Name = "Suzuki" },
               new Manufacturer() { Country = "Japan", Name = "Toyota" },
               new Manufacturer() { Country = "Germany", Name = "Volkswagen" },
            };

            
            var result1 = from car in cars // выберем машины
                         join m in manufacturers on car.Manufacturer equals m.Name // соединим по общему ключу (имя производителя) с производителями
                         select new //   спроецируем выборку в новую анонимную сущность
                         {
                             Name = car.Model,
                             Manufacturer = m.Name,
                             Country = m.Country
                         };


            var result2 = cars.Join(
                            manufacturers, // передаем в качестве параметра вторую коллекцию
                            car => car.Manufacturer, // указываем общее свойство для первой коллекции
                            m => m.Name, // указываем общее свойство для второй коллекции
                            (car, m) => // проекция в новый тип
                            new 
                            {
                                 Name = car.Model,
                                 Manufacturer = m.Name,
                                 Country = m.Country
                            });

            // выведем результаты
            foreach (var item in result2)
                Console.WriteLine($"{item.Name} - {item.Manufacturer} ({item.Country})");
        }

        public static void Method8()
        {
            var departments = new List<Department>()
            {
               new Department() {Id = 1, Name = "Программирование"},
               new Department() {Id = 2, Name = "Продажи"},
               new Department() {Id = 3, Name = "Реклама"},
               new Department() {Id = 4, Name = "Маркетинг"},
            };

            var employees = new List<Employee>()
            {
               new Employee() { DepartmentId = 1, Name = "Инна", Id = 1},
               new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2},
               new Employee() { DepartmentId = 2, Name = "Виктор ", Id = 3},
               new Employee() { DepartmentId = 3, Name = "Альберт ", Id = 4},
            };

            var entity = employees.Join(departments, e => e.DepartmentId, d => d.Id, (d, e) => new { Name = e.Name, DName = d.Name});

            foreach (var item in entity) 
                Console.WriteLine($"{item.Name}: {item.DName}");
        }

        // GroupJoin() - позволяет одновременно с соединение последовательностей, произвести группировку
        public static void Method9()
        {
            // Список моделей
            var cars = new List<Car>()
            {
               new Car() { Model  = "SX4", Manufacturer = "Suzuki"},
               new Car() { Model  = "Grand Vitara", Manufacturer = "Suzuki"},
               new Car() { Model  = "Jimny", Manufacturer = "Suzuki"},
               new Car() { Model  = "Land Cruiser Prado", Manufacturer = "Toyota"},
               new Car() { Model  = "Camry", Manufacturer = "Toyota"},
               new Car() { Model  = "Polo", Manufacturer = "Volkswagen"},
               new Car() { Model  = "Passat", Manufacturer = "Volkswagen"},
            };

            // Список автопроизводителей
            var manufacturers = new List<Manufacturer>()
            {
               new Manufacturer() { Country = "Japan", Name = "Suzuki" },
               new Manufacturer() { Country = "Japan", Name = "Toyota" },
               new Manufacturer() { Country = "Germany", Name = "Volkswagen" },
            };


            // Выборка + группировка
            var result2 = manufacturers.GroupJoin(
               cars, // первый набор данных
               m => m.Name, // общее свойство второго набора
               car => car.Manufacturer, // общее свойство первого набора
               (m, crs) => new  // результат выборки
               {
                   Name = m.Name,
                   Country = m.Country,
                   Cars = crs.Select(c => c.Model)
               });

            // Вывод:
            foreach (var team in result2)
            {
                Console.WriteLine(team.Name + ":");

                foreach (string car in team.Cars)
                    Console.WriteLine(car);

                Console.WriteLine();
            }
        }

        public static void Method10()
        {
            var departments = new List<Department>()
            {
                new Department() {Id = 1, Name = "Программирование"},
                new Department() {Id = 2, Name = "Продажи"}
            };

            var employees = new List<Employee>()
            {
                new Employee() { DepartmentId = 1, Name = "Инна", Id = 1},
                new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2},
                new Employee() { DepartmentId = 2, Name = "Виктор ", Id = 3},
                new Employee() { DepartmentId = 3, Name = "Альберт ", Id = 4},
            };

            var entity = departments.GroupJoin(employees, d => d.Id, e => e.DepartmentId, (a, b) => new { DName = a.Name, ENames = b.Select(x => x.Name)});

            foreach (var item in entity)
            {
                Console.WriteLine(item.DName + ":");

                foreach (string car in item.ENames)
                    Console.WriteLine(car);

                Console.WriteLine();
            }
        }

        // Zip() - данный метод позволяет попарно соединять последовательности
        public static void Method11()
        {
            //  объявляем две коллекции
            var letters = new string[] { "A", "B", "C", "D", "E" };
            var numbers = new int[] { 1, 2, 3 };

            // проводим "упаковку" элементов, сопоставляя попарно
            var q = letters.Zip(numbers, (l, n) => l + n.ToString());

            // вывод: A1 B2 C3
            foreach (var s in q)
                Console.WriteLine(s);
        }
    }

    internal class Employee
    {
        public Employee()
        {
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Contact
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
    internal class Car
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string CountryCode { get; set; }

        public Car()
        {

        }

        public Car(string manufacturer, string countryCode)
        {
            Manufacturer = manufacturer;
            CountryCode = countryCode;
        }
    }
    internal class Manufacturer
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    internal class Department
    {
        public Department()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
