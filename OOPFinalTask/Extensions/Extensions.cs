namespace OOPFinalTask
{
    public static class Extensions
    {
        //Метод расширения
        public static int TotalProductQuantity(this Product[] products)
        {
            int counter = 0;
            for (int i = 0; i < products.Length; i++)
            {
                counter += products[i].ProductQuantity;
            }

            return counter;
        }
    }
}
