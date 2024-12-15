using System;
using static ExceptionsDelegateEventsFinalTask.ExeptionsTask1;

namespace ExceptionsDelegateEventsFinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Исключения
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

            //Делегаты и события




           Console.ReadKey();
        }
    }
}
