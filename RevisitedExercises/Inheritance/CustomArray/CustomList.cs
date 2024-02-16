using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArray
{
    public class CustomList<T>
    {
        private int defaultLength = 4;
        private int currentIndex = 0;
        public CustomList()
        {
            this.List = new T[defaultLength];
        }
        public T[] List { get; set; }

        public void Add(T item)
        {
            CheckIndex();
            this.List[currentIndex++] = item;
        }

        private void CheckIndex()
        {
            if (currentIndex >= this.List.Length)
            {
                this.List = ResizeArray();
            }
        }

        private T[] ResizeArray()
        {
            T[] newArray = new T[this.List.Length * 2];

            for (int i = 0; i < this.List.Length; i++)
            {
                newArray[i] = this.List[i];
            }

            return newArray;
        }
    }
}
