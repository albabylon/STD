namespace OOPFinalTask
{
    //Индексаторы
    //Статический переопрделенный метод
    public class Product
    {
        public string Name { get; set; }
        public int ID { get; set; }

        private decimal productPrice;
        public decimal ProductPrice
        {
            get => productPrice;
            set
            {
                if (value < 0)
                    productPrice = 0;
                productPrice = value;
            }
        }

        private int productQuantity;
        public int ProductQuantity
        {
            get => productQuantity;
            set
            {
                if (value < 0 || value > 1000)
                    productQuantity = 0;
                else
                    productQuantity = value;
            }
        }

        public Product(string name, int id, decimal price, int quantity)
        {
            Name = name;
            ID = id;
            productPrice = price;
            productQuantity = quantity;
        }

        public static int operator +(Product a, Product b)
        {
            return a.ProductQuantity + b.ProductQuantity;
        }
    }

    public class ProductCollection
    {
        private Product[] products;

        public ProductCollection(Product[] products)
        {
            this.products = products;
        }

        public Product this[int id]
        {
            get
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i].ID == id)
                        return products[i];
                }
                return null;
            }
        }
    }
}
