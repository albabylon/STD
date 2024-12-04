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
    public abstract class DeliveryBase
    {
        //Агрегация
        protected AddressBase Address;
        protected decimal Price;
        protected Sender Sender;
        protected Recipient Recipient;
        protected Product[] Products;
        private ProductCollection productsCollection;

        protected DeliveryBase(AddressBase address, Sender sender, Recipient recipient, Product[] products, decimal price)
        {
            Address = address;
            Sender = sender;
            Recipient = recipient;
            Products = products;
            Price = price;
            productsCollection = new ProductCollection(products);
        }

        public abstract void Send();

        public void ShowProductById(int id)
        {
            Console.WriteLine($"Продукт: {productsCollection[id].Name}, {productsCollection[id].ProductPrice} руб, {productsCollection[id].ProductQuantity} шт.");
        }

        public void ShowProducts()
        {
            int i = 1;
            foreach (Product product in Products) 
            {
                Console.WriteLine($"Продукт: {i} - {product.Name}, {product.ProductPrice} руб, {product.ProductQuantity} шт.");
                i++;
            }
        }

        public void TotalQuantity()
        {
            Console.WriteLine($"Итого: {Products.TotalProductQuantity()} шт.");
        }
    }

    public class HomeDelivery : DeliveryBase
    {
        private Courier courier;
        private string addressName;

        public HomeDelivery(AddressHome address, Sender sender, Recipient recipient, Product[] products, decimal price, string courierName, string courierPhoneNumber) : base(address, sender, recipient, products, price)
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

    public class PickPointDelivery : DeliveryBase
    {
        private string addressName;
        private string companyName;

        public PickPointDelivery(AddressPickPoint address, Sender sender, Recipient recipient, Product[] products, decimal price) : base(address, sender, recipient, products, price)
        {
            addressName = address.GetFullAddress();
            companyName = address.CompanyName;
        }

        public override void Send()
        {
            Console.WriteLine($"Посылка отправлена в пункт выдачи {companyName}:\n\nАдрес:{addressName}\n\nОтправитель\nИмя:{Sender.Name}\nТелефон:{Sender.PhoneNumber}\n\nПолучатель\nИмя:{Recipient.Name}\nТелефон:{Recipient.PhoneNumber}");
            Console.WriteLine("----------------");
        }
    }

    public class ShopDelivery : DeliveryBase
    {
        private string addressName;
        private string shopName;

        public ShopDelivery(AddressShop address, Sender sender, Recipient recipient, Product[] products, decimal price) : base(address, sender, recipient, products, price)
        {
            addressName = address.GetFullAddress();
            shopName = address.ShopName;
        }

        public override void Send()
        {
            Console.WriteLine($"Посылка отправлена в магазин {shopName}:\n\nАдрес:{addressName}\n\nОтправитель\nИмя:{Sender.Name}\nТелефон:{Sender.PhoneNumber}\n\nПолучатель\nИмя:{Recipient.Name}\nТелефон:{Recipient.PhoneNumber}");
            Console.WriteLine("----------------");
        }
    }
}