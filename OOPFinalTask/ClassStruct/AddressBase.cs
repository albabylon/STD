using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalTask
{
    public abstract class AddressBase
    {
        public string City;
        public string Street;
        public int HouseNumber;

        protected AddressBase(string city, string street, int houseNumber)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public virtual string GetFullAddress()
        {
            StringBuilder address = new StringBuilder();

            address.Append(City);
            address.Append(", ");
            address.Append(Street);
            address.Append(", ");
            address.Append(HouseNumber);

            return address.ToString();
        }
    }

    public class AddressHome : AddressBase
    {
        public int FloorNumber;
        public int FlatNumber;

        protected AddressHome(string city, string street, string postalCode, int houseNumber, int floorNumber, int flatNumber) : base(city, street, houseNumber)
        {
            FloorNumber = floorNumber;
            FlatNumber = flatNumber;
        }

        public override string GetFullAddress()
        {
            StringBuilder address = new StringBuilder();

            string baseAddress = base.GetFullAddress();
            address.Append(baseAddress);
            address.Append(", ");
            address.Append("эт.");
            address.Append(FloorNumber);
            address.Append(", ");
            address.Append("кв.");
            address.Append(FlatNumber);

            return address.ToString();
        }
    }

    public class AddressPickPoint : AddressBase
    {
        public string CompanyName;
        public AddressPickPoint(string city, string street, string postalCode, int houseNumber, string companyName) : base(city, street, houseNumber)
        {
            CompanyName = companyName;
        }
    }

    public class AddressShop : AddressBase
    {
        public string ShopName;
        public AddressShop(string city, string street, string postalCode, int houseNumber, string shopName) : base(city, street, houseNumber)
        {
            ShopName = shopName;
        }
    }
}
