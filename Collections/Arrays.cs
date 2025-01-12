using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Arrays
    {
        // МАССИВЫ
        // Массив или array — это простейшая коллекция. Представляет собой набор данных одного типа (например, целых чисел int, строк string и тд).
        // В большинстве случаев массив используется тогда, когда мы сразу получаем все объекты, которые будем в нём хранить и знаем, сколько памяти нам потребуется
        int[] one = new int[4] { 1, 2, 3, 5 };
        int[] two = new int[] { 1, 2, 3, 5 };
        int[] three = new[] { 1, 2, 3, 5 };
        int[] four = { 1, 2, 3, 5 };
        // Обращение по несуществующему индексу массива вызовет System.IndexOutOfRangeException
    }
}
