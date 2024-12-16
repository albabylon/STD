using System;
using System.Linq;
using static ExceptionsDelegateEventsFinalTask.TaskExeptions;

namespace ExceptionsDelegateEventsFinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Задание 1 - Исключения
            Exception[] exceptions = new Exception[5];
            exceptions[0] = new IndexOutOfRangeException();
            exceptions[1] = new FormatException();
            exceptions[2] = new ArgumentNullException();
            exceptions[3] = new DivideByZeroException();
            exceptions[4] = new NotUniqElemenToAddException("Добавлен не уникальный элемент", "Элемент 012");

            for (int i = 0; i < exceptions.Length; i++)
            {
                try
                {
                    throw exceptions[i];
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}\n{ex.GetBaseException()}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}\n{ex.GetBaseException()}");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}\n{ex.GetBaseException()}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}\n{ex.GetBaseException()}");
                }
                catch (NotUniqElemenToAddException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}, Элемент: {ex.ElementName}\n{ex.GetBaseException()}");
                }
                finally
                {
                    Console.WriteLine("------------------");
                }
            }
            #endregion
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            #region Задание 2 - Делегаты и события
            SurnamesReader reader = new SurnamesReader();
            reader.SortSurnamesEvent += SortSurnames;

            try
            {
                reader.GetSortedSurnames();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Сортировка проведена");
            }
            #endregion

            Console.ReadKey();
        }

        private static void SortSurnames(string[] surnames, int value)
        {
            string[] result = new string[surnames.Length];
            switch (value)
            {
                case 1:
                    result = surnames.OrderBy(x => x).ToArray();
                    break;
                case 2:
                    result = surnames.OrderByDescending(x => x).ToArray();
                    break;
            }

            foreach (string s in result)
                Console.WriteLine(s);
        }
    }
}
