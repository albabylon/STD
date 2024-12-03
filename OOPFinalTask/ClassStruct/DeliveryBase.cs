using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalTask
{
    public abstract class DeliveryBase<TAddress> where TAddress : AddressBase
    {
        public TAddress Address;
        public decimal Price;
        public Sender Sender;
        public Recipient Recipient;

        protected DeliveryBase(TAddress address, decimal price, Sender sender, Recipient recipient)
        {
            Address = address;
            Price = price;
            Sender = sender;
            Recipient = recipient;
        }

        public abstract void Send();
    }

    public class HomeDelivery : DeliveryBase<AddressHome>
    {
        public Courier Courier;
        public string AddressName;

        protected HomeDelivery(AddressHome address, decimal price, Sender sender, Recipient recipient, Courier courier) : base(address, price, sender, recipient)
        {
            Courier = courier;
            AddressName = address.GetFullAddress();
        }

        public override void Send()
        {
            Console.WriteLine($"Посылка отправлена домой:\nАдрес:{AddressName}\nОтправитель\nИмя:{Sender.Name}\nТелефон:{Sender.Name}\nПолучатель\nИмя:{Recipient.Name}\nТелефон:{Recipient.Name}\nКурьер\nИмя:{Courier.Name}\nТелефон:{Courier.Name}");
        }
    }

    public class PickPointDelivery : DeliveryBase<AddressPickPoint>
    {
        public string AddressName;

        public PickPointDelivery(AddressPickPoint address, decimal price, Sender sender, Recipient recipient) : base(address, price, sender, recipient)
        {
            AddressName = address.GetFullAddress();
        }

        public override void Send()
        {
            Console.WriteLine($"Посылка отправлена в пункт выдачи {Address.CompanyName}:\nАдрес:{AddressName}\nОтправитель\nИмя:{Sender.Name}\nТелефон:{Sender.Name}\nПолучатель\nИмя:{Recipient.Name}\nТелефон:{Recipient.Name}");
        }
    }

    public class ShopDelivery : DeliveryBase<AddressShop>
    {
        public string AddressName;

        public ShopDelivery(AddressShop address, decimal price, Sender sender, Recipient recipient) : base(address, price, sender, recipient)
        {
            AddressName = address.GetFullAddress();
        }

        public override void Send()
        {
            Console.WriteLine($"Посылка отправлена в магазин {Address.ShopName}:\nАдрес:{AddressName}\nОтправитель\nИмя:{Sender.Name}\nТелефон:{Sender.Name}\nПолучатель\nИмя:{Recipient.Name}\nТелефон:{Recipient.Name}");
        }
    }
}