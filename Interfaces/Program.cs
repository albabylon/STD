using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Абстрактный класс задаёт иерархию наследования. Тем самым, он создает функциональные возможности для производных классов.

            //Интерфейс же описывает только действия.Он позволяет определить только функциональность.
            //И хотя класс может расширять только один абстрактный класс, интерфейсов он может использовать несколько.


            //Когда лучше использовать абстрактные классы?
            //Выгодно использовать их, когда вы уверены в необходимости общей реализации.
            //Когда бизнес логика в одном классе обязательно должна присутствовать и в производном без какого-либо копипаста кода благодаря абстрактным классам и наследованию в ООП.

            //Когда лучше использовать интерфейсы?
            //Когда вы точно знаете, что общая реализация не нужна. Когда вы уверены в том, что не понадобится повторять код в производных классах.
            //Интерфейсы в данном случае отлично подойдут для завязывания контрактов между классами, тем самым диктуя производным классам выполнять бизнес - логику ваших контрактов.
            //При этом у вас ещё остаётся место для наследования от другого класса. 

            //явная и неявная реализация интерфейса
            NewMessenger newMessenger = new NewMessenger();
            newMessenger.SendMessage("Hello World!");
            ((IWhatsApp)newMessenger).SendMessage("Hello World!");
            ((IViber)newMessenger).SendMessage("Hello World!");


            Console.WriteLine("\n\n\n");

            //множественна реализация
            IReader reader = new FileManager();
            IWriter writer = new FileManager();
            IMailer mailer = new FileManager();
            FileManager fileManager = new FileManager();
            reader.Read();
            writer.Write();
            mailer.Read();
            mailer.SendEmail();
            fileManager.Do();

            //ковариантность и контравариантость - только в обобщенных интерфейсах и со словом out для ковариации и in для контравариации
            //Ковариантность позволяет использовать более конкретный тип, чем тип, который задан изначально.
            //Контравариантность позволяет использовать более универсальный тип, чем тип, который задан изначально.
            //пример одновременной ковариации и контравариации
            IGarageManager<Car, Garage> garageManager = new GarageManagerBase();
            IGarageManager<Bike, Garage> garageManager1 = new GarageManagerBase(); //контравариантность
            IGarageManager<Car, House> garageManager2 = new GarageManagerBase(); //ковариантность

            Console.Read();
        }

        //для явная и неявная реализация
        public class NewMessenger : IWhatsApp, IViber
        {
            public void SendMessage(string message)
            {
                Console.WriteLine("{0} : {1}", "Nothing", message);
            }

            //явная реализация интерфейса
            void IWhatsApp.SendMessage(string message)
            {
                Console.WriteLine("{0} : {1}", "WhatsApp", message);
            }

            void IViber.SendMessage(string message)
            {
                Console.WriteLine("{0} : {1}", "Viber", message);
            }
        }
        public interface IWhatsApp
        {
            void SendMessage(string message);
        }
        public interface IViber
        {
            void SendMessage(string message);
        }

        //для множественной реализации
        public class FileManager : IWriter, IReader, IMailer
        {
            void IReader.Read()
            {
                Console.WriteLine("Выполнен метод Read из IReader...");
            }

            void IMailer.Read()
            {
                Console.WriteLine("Выполнен метод Read из IMailer...");
            }

            void IMailer.SendEmail()
            {
                Console.WriteLine("Выполнен метод SendEmail из IMailer...");
            }

            void IWriter.Write()
            {
                Console.WriteLine("Выполнен метод Write из IWriter...");
            }

            public void Do()
            {
                Console.WriteLine("Выполнен метод Do из класса FileManager...");
            }
        }
        public interface IWriter
        {
            void Write();
        }
        public interface IReader
        {
            void Read();
        }
        public interface IMailer
        {
            void SendEmail();
            void Read();
        }

        //для ковариантность и контравариантость
        public class Car 
        {
            
        }
        public class Bike : Car
        {

        }
        public class House
        {

        }
        public class Garage : House
        { 

        }
        public interface IGarageManager<in T, out Z>
        {
            Z GetGarageInfo();
            void Add(T car);
        }
        public class GarageManagerBase : IGarageManager<Car, Garage>
        {
            public void Add(Car car)
            {
                throw new NotImplementedException();
            }

            public Garage GetGarageInfo()
            {
                throw new NotImplementedException();
            }
        }
    }
}
