using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private IProduct[] products;
        private int currentIndex = 0;
        public ProductStock(IProduct[] products)
        {
            this.products = products;
        }
        public IProduct this[int index]
        {
            get => products[index];
            set => products[index] = value;
        }

        public int Count => currentIndex;

        public void Add(IProduct product)
        {
            products[currentIndex] = product;
            currentIndex++;
        }

        public bool Contains(IProduct product)
        {
            throw new NotImplementedException();
        }

        public IProduct Find(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            throw new NotImplementedException();
        }

        public IProduct FindByLabel(string label)
        {
            throw new NotImplementedException();
        }

        public IProduct FindMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public bool Remove(IProduct product)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
