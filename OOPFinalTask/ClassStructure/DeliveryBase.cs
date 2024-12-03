using System;

namespace OOPFinalTask
{
    //Наследование
    //Абстрактный класс с абстрактным членом класса
    //Переопределение методов
    //Конструктор с параметрами
    //Использование обобщений
    //Композиция классов
    //Агрегация классов
    public abstract class DeliveryBase<TAddress> where TAddress : AddressBase
    {
        //Агрегация
        protected TAddress Address;
        protected decimal Price;
        protected Sender Sender;
        protected Recipient Recipient;
        protected ProductCollection Products;

        protected DeliveryBase(TAddress address, Sender sender, Recipient recipient, ProductCollection products, decimal price)
        {
            Address = address;
            Sender = sender;
            Recipient = recipient;
            Products = products;
            Price = price;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Вызвана доставка");
            Console.ResetColor();
        }

        public abstract void Send();
        public void ShowProductById(int id)
        {
            Console.WriteLine("+++++++++++++++++");
            Console.WriteLine($"Продукт: {Products[id].Name}, {Products[id].ProductPrice} руб, {Products[id].ProductQuantity} шт.");
            Console.WriteLine("+++++++++++++++++");
        }
    }

    public class HomeDelivery : DeliveryBase<AddressHome>
    {
        private Courier courier;
        private string addressName;

        public HomeDelivery(AddressHome address, Sender sender, Recipient recipient, ProductCollection products, decimal price, string courierName, string courierPhoneNumber) : base(address, sender, recipient, products, price)
        {
            //Композиция
            courier = new Courier(courierName, courierPhoneNumber);
            addressName = address.GetFullAddress();
        }

        public override void Send()
        {
            Console.WriteLine($"Посылка отправлена на дом:\n\nАдрес:{addressName}\n\nОтправитель\nИмя:{Sender.Name}\nТелефон:{Sender.PhoneNumber}\n\nПолучатель\nИмя:{Recipient.Name}\nТелефон:{Recipient.PhoneNumber}\n\nКурьер\nИмя:{courier.Name}\nТелефон:{courier.PhoneNumber}");
            Console.WriteLine("----------------");
        }
    }

    public class PickPointDelivery : DeliveryBase<AddressPickPoint>
    {
        private string addressName;

        public PickPointDelivery(AddressPickPoint address, Sender sender, Recipient recipient, ProductCollection products, decimal price) : base(address, sender, recipient, products, price)
        {
            addressName = address.GetFullAddress();
        }

        public override void Send()
        {
            Console.WriteLine($"Посылка отправлена в пункт выдачи {Address.CompanyName}:\n\nАдрес:{addressName}\n\nОтправитель\nИмя:{Sender.Name}\nТелефон:{Sender.PhoneNumber}\n\nПолучатель\nИмя:{Recipient.Name}\nТелефон:{Recipient.PhoneNumber}");
            Console.WriteLine("----------------");
        }
    }

    public class ShopDelivery : DeliveryBase<AddressShop>
    {
        private string addressName;

        public ShopDelivery(AddressShop address, Sender sender, Recipient recipient, ProductCollection products, decimal price) : base(address, sender, recipient, products, price)
        {
            addressName = address.GetFullAddress();
        }

        public override void Send()
        {
            Console.WriteLine($"Посылка отправлена в магазин {Address.ShopName}:\n\nАдрес:{addressName}\n\nОтправитель\nИмя:{Sender.Name}\nТелефон:{Sender.PhoneNumber}\n\nПолучатель\nИмя:{Recipient.Name}\nТелефон:{Recipient.PhoneNumber}");
            Console.WriteLine("----------------");
        }
    }
}