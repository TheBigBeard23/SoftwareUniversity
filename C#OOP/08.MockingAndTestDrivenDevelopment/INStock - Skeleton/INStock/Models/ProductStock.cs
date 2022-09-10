using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private IProduct[] products;
        private int currentIndex;
        public ProductStock()
        {
            products = new IProduct[4];
            currentIndex = 0;
        }
        public IProduct this[int index]
        {
            get => products[index];
            set => products[index] = value;
        }

        public int Count => currentIndex;

        public void Add(IProduct product)
        {
            if (Contains(product))
            {
                throw new ArgumentException("Product with that label already exist");
            }
            if (products.Length == currentIndex)
            {
                Resize();
            }
            products[currentIndex] = product;
            currentIndex++;
        }

        private void Resize()
        {
            var newProducts = new IProduct[products.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                newProducts[i] = products[i];
            }

            products = newProducts;
        }

        public bool Contains(IProduct product)
        {
            return products.Contains(product);
        }

        public IProduct Find(int index)
        {
            if (index >= currentIndex)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            return products[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return products
                .Where(p => p != null)
                .Where(p => p.Price == price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return products
                .Where(p => p != null)
                .Where(p => p.Quantity == quantity);
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            return products
                .Where(p => p != null)
                .Where(p => p.Price >= lo
                         && p.Price <= hi)
                .OrderByDescending(p => p.Price);
        }

        public IProduct FindByLabel(string label)
        {
            var product = products
                .Where(p => p != null)
                .Where(p => p.Label == label)
                .FirstOrDefault();

            if (product is null)
            {
                throw new ArgumentException("Product with that label does not exist");
            }

            return product;
        }

        public IProduct FindMostExpensiveProduct()
        {
            var product = products
                .Where(p => p != null)
                .OrderByDescending(p => p.Price)
                .FirstOrDefault();

            if (product is null)
            {
                throw new InvalidOperationException("Product stock is empty");
            }

            return product;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i] == null)
                {
                    break;
                }
                yield return this[i];
            }
        }

        public bool Remove(IProduct product)
        {
            if (!Contains(product))
            {
                return false;
            }

            for (int i = 0; i < Count; i++)
            {
                if (products[i] == product)
                {
                    for (int j = i; j < Count; j++)
                    {
                        if (j + 1 == Count)
                        {
                            currentIndex--;
                            break;
                        }
                        products[j] = products[j + 1];
                    }
                }
            }

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
