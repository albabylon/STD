using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class NongeneralСollections
    {
        // Необобщённые коллекции представляют собой структуры данных общего назначения, оперирующие ссылками на объекты. Благодаря этому в них можно хранить разнотипные данные.
        // Это может быть удобно, например тогда, когда типы хранящихся в коллекции объектов заранее неизвестны.

        // ArrayList
        // Класс ArrayList представляет простейшую коллекцию разнотипных объектов.
        // По сути он является динамическим массивом, то есть может изменять свой размер по мере необходимости(в отличие от обычного массива, в который мы не можем добавить новый элемент, не переопределяя его).

        private void Method()
        {
            var arrayList = new ArrayList() { 2, "Lol" };
            
            arrayList.Add(1);
            arrayList.Add("string");
            Class cl = new Class();
            arrayList.Add(cl);
            arrayList.AddRange(new [] { 2, 3, 4 });
            arrayList.GetRange(0, arrayList.Count);
            arrayList.IndexOf(cl);
            arrayList.Insert(0, cl);

            // Объявим ArrayList с элементами разных типов
            var arlist = new ArrayList()
           {
               1,
               "Андрей",
               300,
               4.5f
           };

            // Получим первый элемент по индексу
            int firstElement = (int)arlist[0];

            string secondElement = (string)arlist[1];
            /* int secondElement = (int) arlist[1]; Ошибка (пытаемся привести строку к числу) */

            // используем ключевое слово var, чтобы не приводить к типу
            var firstElementVar = arlist[0]; // получим запакованный объект
            var secondElementVar = arlist[1];
        }

        private class Class
        {
            
        }

    }
}
