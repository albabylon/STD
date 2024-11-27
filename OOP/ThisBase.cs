using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class ThisBase
    {
        //this - для обращения к скрытой переменной внутри класса
        //this - для передачи одного конструктора другому через this()
        //base - для обращения к базовому классу
        //base - для передачи конструктора базового класса наследнику (в случае если в базовом классе только конструктор с параметрами, то мы обязаны передать в наследника)
        class BaseClass
        {
            protected string Name;

            public BaseClass(string name)
            {
                Name = name;
            }
        }

        class DerivedClass : BaseClass
        {
            public string Description;

            public int Counter;

            public DerivedClass(string Name, string Description) : base(Name)
            {
                this.Description = Description;
            }

            public DerivedClass(string Name, string Description, int counter) : this(Name, Description)
            {
                Counter = counter;
            }
        }

        class AsIs
        {
            class Creature { }

            class Animal : Creature { }

            class Human : Creature { }

            class HomoSapiens : Human { }

            static void Method()
            {
                HomoSapiens hs = new HomoSapiens();
                Human human = hs;
                Creature creature = (Creature)human;
                Creature secondCreature = new Animal();

                //явное преобразование
                Animal animal = (Animal)secondCreature;
                //неявное невозможно
                //Animal animal1 = secondCreature;

                //явное преобразование можно, но не известно что будет в obj
                object obj2 = new Animal();
                Animal animal2 = (Animal)obj2;
                //будет ошибка
                object obj3 = new object();
                Animal animal3 = (Animal)obj3;

                //проеверка преобразования, при проверка на наследнико тоже будет true
                if (secondCreature is Animal)
                {
                    Console.WriteLine("Экземпляр имеет тип Animal");
                }

                //преобразование в animal, но нужна проверка на null
                Animal animal4 = secondCreature as Animal;
                if (animal4 != null)
                {
                    // Использование значения animal
                }

                //сопоставление шаблонов - способ проверяет тип и если все ок, то будет доступна animal внтури if
                if (secondCreature is Animal animal5)
                {
                    // Использование значения animal
                }
            }
        }

    }
}
