using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ImplementCustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> items;

        public CustomStack()
        {
            items = new List<T>();
        }
        public CustomStack(List<T> items)
        {
            this.items = items;
        }
        public T Pop()
        {
            if (items.Count > 0)
            {
                T element = items[items.Count - 1];
                items.RemoveAt(items.Count - 1);
                return element;
            }
            else
            {
                Console.WriteLine("No elements");
                return default;
            }
        }
        public void Push(T element)
        {
            items.Add(element);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
