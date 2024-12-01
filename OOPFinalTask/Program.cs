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

        }
    }

    abstract class DeliveryBase
    {
        public string Address;
    }

    class HomeDelivery : DeliveryBase
    {

    }

    class PickPointDelivery : DeliveryBase
    {

    }

    class ShopDelivery : DeliveryBase
    {

    }

    class Order<TDelivery, TStruct> where TDelivery : DeliveryBase
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }
    }


    class AddressBase
    {

    }
    //сделать индексирование по выбору пункты выдачи
}
