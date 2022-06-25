using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStackAndQueue
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;
        public CustomList()
        {
            Count = 0;
            items = new int[InitialCapacity];
        }
        public CustomList(int capacity)
            : this()
        {
            items = new int[capacity];
        }
        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                CheckIfIndexOutOfRangeThrowException(index);
                return items[index];
            }

            set
            {
                CheckIfIndexOutOfRangeThrowException(index);
                items[index] = value;
            }
        }
        public CustomList Reverse()
        {
            var reversedList = new CustomList();

            for (int i = Count - 1; i >= 0; i--)
            {
                reversedList.Add(items[i]);
            }

            return reversedList;
        }
        public CustomList Find(Predicate<int> predicate)
        {
            var newList = new CustomList();

            foreach (var item in items)
            {
                if (predicate(item))
                {
                    newList.Add(item);
                }
            }

            return newList;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIfIndexOutOfRangeThrowException(firstIndex);
            CheckIfIndexOutOfRangeThrowException(secondIndex);

            int firstElement = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = firstElement;
        }
        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }
        public void Add(int item)
        {
            Resize();

            items[Count] = item;
            Count++;
        }
        public void Insert(int index, int element)
        {
            CheckIfIndexOutOfRangeThrowException(index);
            if (Count == items.Length)
            {
                Resize();
            }
            ShiftToRight(index);
            items[index] = element;
            Count++;

        }
        public int RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int element = items[index];
            items[index] = default(int);
            Shift(index);
            Count--;
            Shrink();

            return element;
        }
        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }
        private void Shrink()
        {
            if (items.Length / 4 >= Count)
            {
                int[] newArray = new int[items.Length / 2];

                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = items[i];
                }

                items = newArray;
            }
        }
        private void Shift(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }
        private void Resize()
        {
            if (Count == items.Length)
            {
                int[] newArray = new int[items.Length * 2];

                for (int i = 0; i < items.Length; i++)
                {
                    newArray[i] = items[i];
                }

                items = newArray;
            }
        }
        private void CheckIfIndexOutOfRangeThrowException(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                sb.Append($"{items[i]} ");
            }

            return sb.ToString();
        }


    }
}
