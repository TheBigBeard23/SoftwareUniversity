using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList
{
    public class LinkedList
    {
        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            var newNode = new Node(element);

            if (Count == 0)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.NextNode = head;
                head.PreviousNode = newNode;
                head = newNode;
            }

            Count++;
        }
        public void AddLast(int element)
        {
            var newNode = new Node(element);

            if (Count == 0)
            {
                head = tail = newNode;
            }
            else
            {
                tail.NextNode = newNode;
                newNode.PreviousNode = tail;
                tail = newNode;
            }

            Count++;
        }
        public int RemoveFirst()
        {
            CheckIfEmptyThrowException();

            var value = head.Value;
            head = head.NextNode;

            if (head == null)
            {
                tail = null;
            }
            else
            {
                head.PreviousNode = null;
            }
            Count--;
            return value;
        }
        public int RemoveLast()
        {
            CheckIfEmptyThrowException();

            var value = tail.Value;
            tail = tail.PreviousNode;

            if (tail == null)
            {
                head = null;
            }
            else
            {
                tail.NextNode = null;
            }
            Count--;
            return value;
        }
        public void ForEach(Action<int> action)
        {
            var crnNode = head;

            while (crnNode!=null)
            {
                action(crnNode.Value);
                crnNode = crnNode.NextNode;
            }

        }
        public int[] ToArray()
        {
            int[] array = new int[Count];

            var crnNode = head;
            int counter = 0;

            while (crnNode != null)
            {
                array[counter] = crnNode.Value;
                crnNode = crnNode.NextNode;
                counter++;
            }

            return array;

        }
        private void CheckIfEmptyThrowException()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("LinkedList is empty!");
            }
        }
    }
}
