using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int currentIndex = 0;
        public ListyIterator(params T[] items)
        {
            this.items = new List<T>(items);
        }
        public bool Move() => ++currentIndex < items.Count;
        public bool HasNext() => currentIndex + 1 < items.Count ? true : false;
        public void Print()
        {
            if (currentIndex < items.Count)
            {
                Console.WriteLine(items[currentIndex]);
            }
            else
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
