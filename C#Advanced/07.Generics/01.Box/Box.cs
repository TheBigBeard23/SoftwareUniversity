using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    class Box<T>
    {
        public Box()
        {
            Stack = new Stack<T>();
        }
        public Stack<T> Stack { get; set; }
        public int Count => Stack.Count;
        public void Add(T element)
        {
            Stack.Push(element);
        }
        public T Remove()
        {
            return Stack.Pop();
        }

    }
}
