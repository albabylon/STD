using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Generic
    {
        public abstract class Car<TEngine> where TEngine : Engine
        {
            public TEngine Engine = default(TEngine);
            public virtual void ChangePart<TPart>(TPart newPart) where TPart : Part
            {

            }
        }
        public class ElectricalCar : Car<ElectricEngine>
        {
            public override void ChangePart<TPart>(TPart newPart)
            {

            }
        }
        public class GasCar : Car<GasEngine>
        {
            public override void ChangePart<TPart>(TPart newPart)
            {

            }
        }

        public abstract class Engine
        {

        }
        public class ElectricEngine : Engine
        {

        }
        public class GasEngine : Engine
        {

        }

        public abstract class Part 
        {
            
        }
        public class Battery : Part
        {

        }
        public class Differential : Part
        {

        }
        public class Wheel : Part
        {
            
        }
    }
}
