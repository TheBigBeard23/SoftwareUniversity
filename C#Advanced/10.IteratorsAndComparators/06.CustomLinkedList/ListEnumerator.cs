using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList
{
    public class ListEnumerator<T> : IEnumerator<T>
    {
        private Node<T> head;
        private Node<T> currentNode;
        public ListEnumerator(Node<T> head)
        {
            Reset();
            currentNode = head;
            this.head = head;
        }
        public T Current => currentNode.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            currentNode = currentNode.Next;

            return currentNode != null;
        }

        public void Reset() => currentNode = head;
    }
}
