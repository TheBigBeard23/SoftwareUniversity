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

            stock = new ProductStock();
            stock.Add(product);
        }

        [Test]
        public void AddMethod_ShouldThrowException_WhenProductAlreadyExist()
        {
            Assert.Throws<ArgumentException>(() => stock.Add(product));

        }

        [Test]
        public void AddMethod_ShouldAddProduct_WhenProductDoesNotExist()
        {
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
        public void FindMethod_ShouldThorwException_WhenIndexIsOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            stock.Find(1));
        }

        [Test]
        public void FindMethod_ShouldReturnProductByIndex()
        {
            Assert.AreEqual(product, stock.Find(0));
        }

        [Test]
        public void FindByLabelMethod_ShouldReturnProduct_IfProductWithThatLabelExist()
        {
            Assert.AreEqual(product, stock.FindByLabel(product.Label));
        }

        [Test]
        public void FindByLabelMethod_ShouldThrowException_WhenProductWithThatLabelDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
            stock.FindByLabel("label"));
        }

        [Test]
        public void FindAllInPriceRangeMethod_ShouldReturnEmptyCollection_WhenProductsDoNotMatch()
        {
            var foundProducts = stock.FindAllInRange(price + 1, price + 2);

            Assert.That(foundProducts, Is.Empty);
        }
        [Test]
        public void FindAllInPriceRangeMethod_ShouldReturnProductByPriceInRangeOrderedByPriceDescending()
        {
            stock.Add(new Product("Milk", 2, 1));
            stock.Add(new Product("Bread", 3, 1));
            stock.Add(new Product("Fish", 4, 1));
            stock.Add(new Product("Meat", 5, 1));
            stock.Add(new Product("Burger", 6, 1));

            int lo = 1;
            int hi = 100;

            var expectedProducts = stock
                .Where(p => p.Price >= lo
                         && p.Price <= hi)
                .OrderByDescending(p => p.Price);

            var actualProducts = stock.FindAllInRange(1, 100);

            Assert.That(expectedProducts, Is.EquivalentTo(actualProducts));
        }

        [Test]
        public void FindAllByPriceMethod_ShouldReturnEmptyCollection_WhenProductsWithThatPriceDoesNotExist()
        {
            var result = stock.FindAllByPrice(price + 1);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllByPriceMethod_ShouldReturnProductsByPrice()
        {

            stock.Add(new Product("Milk", 2, 1));
            stock.Add(new Product("Bread", 2, 1));
            stock.Add(new Product("Fish", 2, 1));

            var expectedProducts = stock.Where(t => t.Price == 2);
            var actualProducts = stock.FindAllByPrice(2);

            Assert.That(expectedProducts, Is.EquivalentTo(actualProducts));
        }

        [Test]
        public void FindMostExpensiveProductsMethod_ShouldThrowException_WhenProductStockIsEmpty()
        {
            stock = new ProductStock();
            Assert.Throws<InvalidOperationException>(() => stock.FindMostExpensiveProduct());
        }

        [Test]
        public void FindMostExpensiveProductsMethod_ShouldReturnMostExpensiveProduct()
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
            stock.Add(new Product("Milk", 2, quantity));
            stock.Add(new Product("Bread", 6, quantity));

            Assert.AreEqual(3, stock.FindAllByQuantity(quantity).Count());

        }

        [Test]
        public void FindAllByQuantityMethod_ShouldReturnEmptyEnumeration()
        {
            Assert.AreEqual(0, stock.FindAllByQuantity(quantity + 1).Count());
        }

        [Test]
        public void Remove_ShouldReturnTrue_WhenProductHasBeenRemoved()
        {
            Assert.IsTrue(stock.Remove(product));
        }

        [Test]
        public void Remove_ShouldReturnFalse_WhenProductDoesNotExist()
        {
            Assert.IsFalse(stock.Remove(new Product("label", 100, 100)));
        }

        [Test]
        public void GetEnumerator_ShouldWorkCorrectly()
        {
            var products = new ProductStock();

            stock = new ProductStock();
            stock.Add(new Product("Milk", 2, 1));
            stock.Add(new Product("Bread", 3, 1));
            stock.Add(new Product("Fish", 4, 1));
            stock.Add(new Product("Meat", 5, 1));
            stock.Add(new Product("Burger", 6, 1));

            foreach (var product in stock)
            {
                products.Add(product);
            }

            Assert.That(stock, Is.EquivalentTo(products));

        }

        [Test]
        public void Indexer_ShouldWorkCorrectly()
        {
            Assert.AreEqual(product, stock[0]);
        }



    }
}
