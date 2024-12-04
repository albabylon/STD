using System;

namespace OOPFinalTask
{
    public static class Extensions
    {
        //Метод расширения
        //Метод с обобщением
        public static int TotalProductQuantity(this Product[] products)
        {
            int counter = 0;
            for (int i = 0; i < products.Length; i++)
            {
                counter += products[i].ProductQuantity;
            }

            return counter;
        }

        public static void GetOrderNumber<T>(this T a) where T : Order<DeliveryBase>
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            
            Console.Write($"Номер заказа: {a.Number}\n");

            Console.ResetColor();
        }
    }
}
