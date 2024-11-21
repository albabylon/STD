using System;
using System.Collections;

namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInt = GetArrayFromConsole(10);

            ShowArray(arrayInt, true);

            Console.ReadLine();
        }

        static int[] GetArrayFromConsole(int num = 5)
        {
            var result = new int[num];

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Введите элемент массива номер {0}", i + 1);
                result[i] = int.Parse(Console.ReadLine());
            }

            return result;
        }

        static int[] SortArray(int[] arrayInt)
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
                result = SortArray(array);

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
    }
}
