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
            ProductStock stock = new ProductStock();

                stock.Add(new Product("label", 10, 1));
            stock.FindByLabel("ds");
        }
    }
}
