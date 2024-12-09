using System;
using System.Collections.Generic;

namespace DelegateExample
{
    public delegate bool LegitToPromote(Employee employee);
    public class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee() { ID = 01, Name = "Sasha", Salary = 5000, Experience = 3 };
            Employee employee2 = new Employee() { ID = 02, Name = "Stepa", Salary = 23000, Experience = 5 };

            List<Employee> employees = new List<Employee>
            {
                employee1,
                employee2
            };

            LegitToPromote legitToPromote = Promote;

            Employee.PromoteEmployee(employees, legitToPromote);

            Console.ReadLine();
        }

        public static bool Promote(Employee employee)
        {
            if (employee.Salary > 10000)
                return false;
            return true;
        }
    }


    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }

        public static void PromoteEmployee(List<Employee> employees, LegitToPromote IsLegitToPromote)
        {
            foreach (Employee employee in employees)
            {
                if (IsLegitToPromote(employee))
                    Console.WriteLine("Работник {0} повышен", employee.Name);
            }
        }
    }
}
