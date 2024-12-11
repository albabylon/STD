using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Событие — это уведомление, отправляемое объектом, чтобы сигнализировать о возникновении действия.
            //Класс, который вызывает события, называется издателем
            //Класс, который получает уведомление, называется подписчиком

            //Событие объявляется в 2 этапа:
            //1.Объявление делегата.
            //2.Объявление переменной делегата с ключевым словом Event.

            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.ProcessCompleted += bl_ProcessCompleted; // регистрируем событие
            bl.StartProcess();
        }

        // перехватчик событий
        public static void bl_ProcessCompleted()
        {
            Console.WriteLine("Процесс завершён!");
        }

        public delegate void Notify();  // делегат                
        public class ProcessBusinessLogic
        {
            public event Notify ProcessCompleted; // событие

            public void StartProcess()
            {
                Console.WriteLine("Процесс начат!");
                OnProcessCompleted();
            }

            protected virtual void OnProcessCompleted() //protected virtual method
            {
                ProcessCompleted?.Invoke();
            }
        }

    }
}
