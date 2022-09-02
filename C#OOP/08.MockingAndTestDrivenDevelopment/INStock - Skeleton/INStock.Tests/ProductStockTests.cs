namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        private IProductStock stock;
        private IProduct product;
        private IProduct[] products;

        private string label;
        private decimal price;
        private int quantity;

        [SetUp]
        public void SetUp()
        {
            label = "phone";
            price = 100m;
            quantity = 10;
            product = new Product(label, price, quantity);

            IProduct[] products = new IProduct[] { product };
            stock = new ProductStock(products);
        }

        [Test]
        public void AddMethod_ShouldWorkCorrectly()
        {
            Assert.Throws<ArgumentException>(() =>
            stock.Add(product));

            product = new Product("car", 10000, 1);
            int count = stock.Count;
            stock.Add(product);
            Assert.AreEqual(count + 1, stock.Count);
        }

        [Test]
        public void ContainsMethod_ShouldWorkCorrectly()
        {
            Assert.IsTrue(stock.Contains(product));

            product = new Product("car", 10000, 1);
            Assert.IsFalse(stock.Contains(product));
        }

        [Test]
        public void FindMethod_ShouldWorkCorrectly()
        {
            Assert.AreEqual(product, stock.Find(0));
            Assert.Throws<IndexOutOfRangeException>(() =>
            stock.Find(1));
        }

        [Test]
        public void FindByLabelMethod_ShouldReturnProduct_IfProductWithThatLabelExist()
        {
            Assert.AreEqual(product, stock.FindByLabel(product.Label));
        }

        [Test]
        public void FindByLabelMethod_ShouldThrowException_IfProductWithThatLabelDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
            stock.FindByLabel("label"));
        }

        [Test]
        public void FindAllInPriceRangeMethod_ShouldWorkCorrectly()
        {
            decimal lo = 2;
            decimal hi = 6;

            stock.Add(new Product("Milk", 2, 1));
            stock.Add(new Product("Bread", 3, 1));
            stock.Add(new Product("Fish", 4, 1));
            stock.Add(new Product("Meat", 5, 1));
            stock.Add(new Product("Burger", 6, 1));

            var foundProducts = stock.FindAllInRange(lo, hi);
            decimal previousPrice = hi + 1;

            foreach (var product in foundProducts)
            {
                Assert.IsTrue(product.Price >= lo &&
                              product.Price <= hi &&
                              product.Price <= previousPrice);

                previousPrice = product.Price;
            }

            stock = new ProductStock(products);

            foundProducts = stock.FindAllInRange(lo, hi);

            Assert.That(foundProducts, Is.Empty);
        }

        [Test]
        public void FindAllByPriceMethod_ShouldWorkCorrectly()
        {

            stock.Add(new Product("Milk", 2, 1));
            stock.Add(new Product("Bread", 2, 1));
            stock.Add(new Product("Fish", 2, 1));

            var count = stock.FindAllByPrice(2).Count();

            Assert.AreEqual(3, count);

            count = stock.FindAllByPrice(9).Count();

            Assert.AreEqual(0, count);
        }

        [Test]
        public void FindMostExpensiveProductsMethod_ShouldWorkCorrectly()
        {
            product = new Product("Fish", 1000, 1);

            stock.Add(new Product("Milk", 2, 1));
            stock.Add(new Product("Bread", 6, 1));
            stock.Add(product);

            Assert.AreEqual(product, stock.FindMostExpensiveProduct());

        }

        [Test]
        public void FindAllByQuantityMethod_ShouldReturnEnumeration()
        {
            stock.Add(new Product("Milk", 2, 1));
            stock.Add(new Product("Bread", 6, 1));

            Assert.AreEqual(3, stock.FindAllByQuantity(1).Count());

        }

        [Test]
        public void FindAllByQuantityMethod_ShouldReturnEmptyEnumeration()
        {
            Assert.AreEqual(0, stock.FindAllByQuantity(5).Count());
        }

        [Test]
        public void GetEnumerator_ShouldWorkCorrectly()
        {
            Assert.AreEqual(products, );
        }

        [Test]
        public void Indexer_ShouldWorkCorrectly()
        {
            Assert.AreEqual(product, stock[0]);
        }



    }
}
