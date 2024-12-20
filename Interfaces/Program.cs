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

            Console.Read();
        }
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
    }
}
