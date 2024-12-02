using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalTask
{
    public abstract class DeliveryBase<TAddress>
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
        Courier Courier;

        protected HomeDelivery(AddressHome address, decimal price, Sender sender, Recipient recipient, Courier courier) : base(address, price, sender, recipient)
        {
            Courier = courier;
        }

        public override void Send()
        {
            Console.WriteLine($"Посылка отправлена домой:\nОтправитель\nИмя:{Sender.Name}\nТелефон:{Sender.Name}\nПолучатель\nИмя:{Recipient.Name}\nТелефон:{Recipient.Name}\nКурьер\nИмя:{Courier.Name}\nТелефон:{Courier.Name}");
        }
    }

    public class PickPointDelivery : DeliveryBase
    {

    }

    public class ShopDelivery : DeliveryBase
    {

    }
}
