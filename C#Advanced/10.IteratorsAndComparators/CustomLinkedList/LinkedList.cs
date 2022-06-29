using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList
{
    public class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public Node(T value)
        {
            Value = value;
        }

    }
    public class LinkedList<T> : IEnumerable<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }
        public LinkedList()
        {
        }
        public void AddLast(T value)
        {
            var newNode = new Node<T>(value);

            if (Count == 0)
            {
                var firstNode = newNode;
                Head = Tail = firstNode;

                var zeroNode = new Node<T>(value);
                zeroNode.Next = Head;
                Head.Prev = zeroNode;

                Count++;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(Head.Prev);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
