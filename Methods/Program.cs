using System;
using System.Collections;

namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int index = 6;

            //int[] arrayInt = GetArrayFromConsole(ref index);

            //ShowArray(arrayInt, true);

            //Person person1 = new Person();
            //Person person2 = new Person();

            //Person newPerson1 = ChangePerson(person1, 1, "Sasha1");
            //Person newPerson2 = ChangePerson(person2, 2, "Sasha2");

            //Console.WriteLine(newPerson1.Name);
            //Console.WriteLine(newPerson1.Id);

            //Console.WriteLine(newPerson2.Name);
            //Console.WriteLine(newPerson2.Id);

            //var arr = new int[] { 1, 2, 3 };
            //BigDataOperation(arr);

            //Console.WriteLine(arr[0]);

            Echo("Ты тут, братишка?", 4);

            Console.WriteLine(Factorial(20));

            Console.WriteLine(PowerUp(2, 4));

            Console.ReadLine();
        }

        static Person ChangePerson(Person person, int i, string name)
        {
            person.Id = i;
            person.Name = name;

            return person;
        }

        static int[] GetArrayFromConsole(ref int num)
        {
            var result = new int[num];

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Введите элемент массива номер {0}", i + 1);
                result[i] = int.Parse(Console.ReadLine());
            }

            return result;
        }

        static void SortArray(in int[] array, out int[] sorteddesc, out int[] sortedasc)
        {
            sorteddesc = SortArrayDesc(array);
            sortedasc = SortArrayAsc(array);
        }

        static int[] SortArrayDesc(int[] arrayInt)
        {
            int temp = 0;
            for (int i = 0; i < arrayInt.Length; i++)
            {
                for (int j = i + 1; j < arrayInt.Length; j++)
                {
                    if (arrayInt[i] < arrayInt[j])
                    {
                        temp = arrayInt[i];
                        arrayInt[i] = arrayInt[j];
                        arrayInt[j] = temp;
                    }
                }
            }

            return arrayInt;
        }

        static int[] SortArrayAsc(int[] arrayInt)
        {
            int temp = 0;
            for (int i = 0; i < arrayInt.Length; i++)
            {
                for (int j = i + 1; j < arrayInt.Length; j++)
                {
                    if (arrayInt[i] > arrayInt[j])
                    {
                        temp = arrayInt[i];
                        arrayInt[i] = arrayInt[j];
                        arrayInt[j] = temp;
                    }
                }
            }

            return arrayInt;
        }

        static void ShowArray(int[] array, bool isSorted = false)
        {
            int[] result = array;
            if (isSorted)
            {
                SortArray(array, out int[] sorteddesc, out int[] sortedasc);

                result = sorteddesc;
            }

            foreach (int i in result)
            {
                Console.Write(i);
            }
        }

        static void ShowColors(params string[] favcolors)
        {
            Console.WriteLine("Ваши любимые цвета:");
            foreach (var color in favcolors)
            {
                Console.WriteLine(color);
            }
        }

        static void BigDataOperation(in int[] arr)
        {
            arr[0] = 4;
        }

        static void Echo(string saidworld, int deep)
        {
            var modif = saidworld;

            if (modif.Length > 2)
            {
                modif = modif.Remove(0, 2);
            }
            
            Console.BackgroundColor = (ConsoleColor)deep;
            Console.WriteLine("..." + modif);

            if (deep > 1)
            {
                Echo(modif, deep - 1);
            }
        }
        static decimal Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }

        private static int PowerUp(int N, byte pow)
        {
            if (pow == 0) 
            { 
                return 1; 
            }
            else
            {
                if (N == 1)
                {
                    return N;
                }
                else
                {
                    return N * PowerUp(N, --pow);
                }
            }
        }
    }

    class Person
    {
        public string Name { get; set; } = "Start";
        public int Id { get; set; } = 0;
    }
}
