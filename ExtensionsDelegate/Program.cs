using System;
using System.IO;

namespace Extensions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //------------класс Exception------------
            Exception exception = new Exception("Сообщение Message");

            exception.Data.Add("Дата создания: ", DateTime.Now);
            exception.HelpLink = "www.yandex.ru";
            //exception.Message положить в конструктор

            if (exception.Data != null)
                Console.WriteLine($"{exception.Message}, {exception.Data}, {exception.HelpLink}");

            //------------Try Catch Finally------------
            try
            {
                //throw new Exception("Ошибка в БД");

                //int result = Division(7, 0);

                //Console.WriteLine(result);

                Method2();
            }
            catch (Exception ex) when (ex.Message == "Ошибка в БД")
            {
                Console.WriteLine("Ошибка в БД!");
            }
            catch (Exception ex) when (ex is ArgumentNullException)
            {

            }
            catch (FileNotFoundException)
            {

            }
            catch (Exception ex)
            {
                //if (ex is DivideByZeroException) Console.WriteLine("На ноль делить нельзя!");
                //else Console.WriteLine("Произошла непредвиденная ошибка в приложении.");

                Console.WriteLine(ex.StackTrace.ToString());
            }

            finally//необязательныый блок, показывает что должно выполниться независимо от попадания в catch
            {
                Console.WriteLine("Блок Finally сработал!");
            }

            try
            {
                throw new ArgumentOutOfRangeException("Ошибка");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                throw new RankException("Rank Error");
            }
            catch (RankException ex)
            {
                Console.WriteLine(ex.GetType());
            }

            Console.ReadLine();
        }

        static void Method1()
        {
            try
            {
                throw new Exception("Внутреннее исключение");
            }
            catch (Exception)
            {
                throw;
            }
        }

        static void Method2()
        {
            try
            {
                Method1();
            }
            catch (Exception ex)
            {
                //так будет виновник исключения Method2()
                //throw ex;
                //так будет виновник исключения Method1()
                throw;
            }
        }

        static int Division(int a, int b)
        {
            return a / b;
        }
    }
}
