using System;

namespace OOPFinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            ProductCollection productCollection1 = new ProductCollection(products1);

            //Входные данные отправки в пункт выдачи
            Sender sender2 = new Sender("Маша", "+79210933323");
            Recipient recipient2 = new Recipient("Настя", "79110433454");
            AddressPickPoint addres2 = new AddressPickPoint("Москва", "Мясницкая", "345566", 3, "TruePICK");
            Product[] products2 = new Product[]
            {
                new Product("Коробка", 000001, 540, 1),
                new Product("Штаны", 000002, 2240, 3),
            };
            ProductCollection productCollection2 = new ProductCollection(products2);

            //Входные данные отправки в магазин
            Sender sender3 = new Sender("Степан Николаевич", "+79220933466");
            Recipient recipient3 = new Recipient("Виктория Викторовна", "79110895654");
            AddressShop addressShop = new AddressShop("Новосибирск", "Ленина", "687990", 3, "ООО Ромашка");
            Product[] products3 = new Product[]
            {
                new Product("Букет цветов - Розы французкие", 000001, 3150, 1),
                new Product("Букет цветов - Ромашки", 000002, 2250, 3000),
            };
            ProductCollection productCollection3 = new ProductCollection(products3);


            HomeDelivery homeDelivery = new HomeDelivery(addres1, sender1, recipient1, productCollection1, 200, "Иван", "+79230002323");
            homeDelivery.Send();
            
            PickPointDelivery pickPointDelivery = new PickPointDelivery(addres2, sender2, recipient2, productCollection2, 430);
            pickPointDelivery.Send();
            
            ShopDelivery shopDelivery = new ShopDelivery(addressShop, sender3, recipient3, productCollection3, 780);
            shopDelivery.Send();


            //homeDelivery.ShowProductById(000001);
            //int count = products1[0] + products1[1];



            Console.ReadKey();
        }

        public void TotalProduct(Product[] products1) 
        {
            
        }
    }

    public class Order<TDelivery> where TDelivery : DeliveryBase<AddressBase>
    {
        private TDelivery delivery;
        private int number;
        public string Description;

        public Order(TDelivery delivery, int number)
        {
            this.delivery = delivery;
            this.number = number;
        }

        public void ShowInfo(TDelivery delivery)
        {
            delivery.Send();
            delivery.ShowProductById(000001);
        }
    }
}
