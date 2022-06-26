using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> items;
        private int currentIndex = 0;
        public ListyIterator()
        {
            items = new List<T>();
        }
        public ListyIterator(List<T> items)
        {
            this.items = items;
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

    }
}
