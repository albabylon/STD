using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateCovarientContcovarient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ковариация — это когда мы можем объявлять делегат и назначать ему методы другой сигнатуры, но которые являются производными от основного метода.
            CarDelegate carDelegate;
            carDelegate = BuildBMW; //  (делегат возвращает родителя, а метод наследник)
            Car c = carDelegate("X6");
            Console.WriteLine(c.Model);

            //Контравариантность — это когда мы можем объявлять делегат и назначать ему методы другой сигнатуры, но которые являются более универсальными по отношению к типу параметра делегата.
            BwmInfo bmwInfo = GetCarInfo; // контравариантность (делегат принимает наследника, а метод родителя)
            BMW bwm = new BMW
            {
                Model = "X6"
            };
            bmwInfo(bwm);

            //Тестовое
            VehicleDelegate vehicleDelegate = GetVehicle;

            ShowInfoDelegate showInfoDelegate = ShowInfo;
            showInfoDelegate.Invoke(new Child());

            Console.Read();
        }

        //для ковариантности
        delegate Car CarDelegate(string name);
        private static BMW BuildBMW(string model)
        {
            return new BMW { Model = model };
        }
        class Car
        {
            public string Model { get; set; }
        }
        class BMW : Car { }

        //для контравариантности
        delegate void BwmInfo(BMW bwm);
        private static void GetCarInfo(Car p)
        {
            Console.WriteLine(p.Model);
        }

        //тестовое ковариантность
        delegate Vehicle VehicleDelegate(string name); ///наоборот не могут быть типы метода и делегаты
        private static Lexus GetVehicle(string name)
        {
            return null;
        }
        class Vehicle { }
        class Lexus : Vehicle { }

        //тестовое контрвариантность
        delegate void ShowInfoDelegate(Child child);//в делегате должен быть наслденик, а в методе родитель
        private static void ShowInfo(Parent parent)
        {
            Console.Write(parent);
        }
        class Parent { }
        class Child : Parent { }
    }
}
