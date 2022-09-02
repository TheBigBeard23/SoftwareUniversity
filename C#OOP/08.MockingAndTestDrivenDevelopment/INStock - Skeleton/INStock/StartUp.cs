namespace INStock
{
    using INStock.Contracts;
    using INStock.Models;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IProduct[] products = new IProduct[]
            {
                new Product("label1", 1, 2),
                new Product("label2", 1, 2),
                new Product("label3", 1, 2)
            };
            ProductStock stock = new ProductStock(products);

            for (int i = 0; i < stock.Count; i++)
            {
                Console.WriteLine(stock[i].Label);
            }
        }
    }
}
