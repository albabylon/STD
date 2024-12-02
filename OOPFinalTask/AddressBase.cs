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
