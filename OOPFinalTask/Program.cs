using System;

namespace OOPFinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region InputData
            //Входные данные отправки на дом
            Sender sender1 = new Sender("Саша", "+79110922323");
            Recipient recipient1 = new Recipient("Глеб", "+79110452453");
            AddressHome addres1 = new AddressHome("Санкт-Петербург", "Невский", "838432", 22, 2, 228);
            Product[] products1 = new Product[]
            {
                new Product("Пакет яблок", 000001, 150, 1),
                new Product("Куринное филе", 000002, 440, 1),
                new Product("Чипсы Lay's", 000003, 200, 3),
            };

            //Входные данные отправки в пункт выдачи
            Sender sender2 = new Sender("Маша", "+79210933323");
            Recipient recipient2 = new Recipient("Настя", "79110433454");
            AddressPickPoint addres2 = new AddressPickPoint("Москва", "Мясницкая", "345566", 3, "TruePICK");
            Product[] products2 = new Product[]
            {
                new Product("Коробка", 000001, 540, 1),
                new Product("Штаны", 000002, 2240, 3),
            };

            //Входные данные отправки в магазин
            Sender sender3 = new Sender("Степан Николаевич", "+79220933466");
            Recipient recipient3 = new Recipient("Виктория Викторовна", "79110895654");
            AddressShop addressShop = new AddressShop("Новосибирск", "Ленина", "687990", 3, "ООО Ромашка");
            Product[] products3 = new Product[]
            {
                new Product("Букет цветов - Розы французкие", 000001, 3150, 1),
                new Product("Букет цветов - Ромашки", 000002, 2250, 1),
            };
            #endregion

            HomeDelivery homeDelivery = new HomeDelivery(addres1, sender1, recipient1, products1, 200, "Иван", "+79230002323");        
            PickPointDelivery pickPointDelivery = new PickPointDelivery(addres2, sender2, recipient2, products2, 430);            
            ShopDelivery shopDelivery = new ShopDelivery(addressShop, sender3, recipient3, products3, 780);

            Order<DeliveryBase> order1 = new Order<DeliveryBase>(homeDelivery, 001);
            order1.GetOrderNumber();
            order1.ShowInfo();

            Order<DeliveryBase> order2 = new Order<DeliveryBase>(pickPointDelivery, 002);
            order2.GetOrderNumber();
            order2.ShowInfo();

            Order<DeliveryBase> order3 = new Order<DeliveryBase>(shopDelivery, 003);
            order3.GetOrderNumber();
            order3.ShowInfo();

            Console.ReadKey();
        }
    }

    public class Order<TDelivery> where TDelivery : DeliveryBase
    {
        private TDelivery delivery;
        public int Number;
        public string Description;

        public Order(TDelivery delivery, int number)
        {
            this.delivery = delivery;
            Number = number;
        }

        public void ShowInfo()
        {
            delivery.Send();
            delivery.ShowProducts();
            delivery.TotalQuantity();
            
            //delivery.ShowProductById(000001);
            Console.WriteLine();
        }
    }
}
