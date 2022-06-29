using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStackAndQueue
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items;
        private int count;
        public CustomStack()
        {
            items = new int[InitialCapacity];
            count = 0;
        }
        public CustomStack(int initialCapacity)
            : this()
        {
            items = new int[initialCapacity];
        }
        public int Count { get; }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
            }
        }
        public int Peek()
        {
            CheckStackIsEmpty();

            int element = items[count - 1];

            return element;
        }
        public int Pop()
        {
            CheckStackIsEmpty();

            int element = items[count - 1];
            items[count - 1] = default(int);
            count--;

            return element;
        }
        public void Push(int element)
        {
            if (items.Length == count)
            {
                var newArray = new int[items.Length * 2];
                for (int i = 0; i < count; i++)
                {
                    newArray[i] = items[i];
                }
                items = newArray;
            }
            items[count] = element;
            count++;
        }
        private void CheckStackIsEmpty()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
        }
    }
}
