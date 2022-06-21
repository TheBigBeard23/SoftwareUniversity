using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList
{
    public class CustomLinkedList<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }
            public Node(T value)
            {
                Value = value;
            }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }
        public void AddFirst(T element)
        {
            var newNode = new Node(element);

            if (Count == 0)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
            Count++;
        }
        public void AddLast(T element)
        {
            var newNode = new Node(element);

            if (Count == 0)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Prev = tail;
                tail.Next = newNode;
                tail = newNode;
            }
            Count++;
        }
        public T RemoveFirst(T element)
        {
            CheckIfEmptyThrowException();

            var firstElement = head.Value;
            head = head.Next;

            if (head != null)
            {
                head.Prev = null;
            }
            else
            {
                tail = null;
            }

            Count--;
            return firstElement;
        }
        public T RemoveLast(T element)
        {
            CheckIfEmptyThrowException();

            var lastElement = tail.Value;
            tail = tail.Prev;

            if (tail != null)
            {
                tail.Next = null;
            }
            else
            {
                head = null;
            }

            Count--;
            return lastElement;
        }
        public void ForEach(Action<T> action)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
        public T[] ToArray()
        {
            T[] array = new T[Count];
            int counter = 0;
            var currentNode = head;
            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.Next;
                counter++;
            }
            return array;
        }
        private void CheckIfEmptyThrowException()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomLinkedList is empty!");
            }
        }

    }
}
