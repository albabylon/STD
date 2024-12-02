using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Отправитель
            //Набор продуктов
            //Выбор типа доставки
            //Заказ сформирован

            //По типу доставки выбирается Курьер
            //По типу Получатель
        }
    }

    public class Order<TDelivery, TStruct> where TDelivery : DeliveryBase
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }
    }







    //сделать индексирование по выбору пункты выдачи
}
