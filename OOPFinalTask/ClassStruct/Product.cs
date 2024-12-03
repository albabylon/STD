using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalTask
{
    public class Product
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public decimal ProductPrice {  get; set; }

        private int productQuantity;
        public int ProductQuantity
        {
            get => productQuantity;
            set
            {
                if (value < 0 || value > 1000)
                    throw new ArgumentOutOfRangeException("Количество товара не в рамках разумного");
                else
                    productQuantity = value;
            }
        }
    }

    public class  ProductCollection
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
