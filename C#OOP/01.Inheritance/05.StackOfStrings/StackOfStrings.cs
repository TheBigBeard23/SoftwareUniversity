using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        private Stack<string> stack;
        public StackOfStrings()
        {
            stack = new Stack<string>();
        }
        public StackOfStrings(string[] array)
        {
            stack = new Stack<string>(array);
        }
        public bool IsEmpty()
        {
            if (stack.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Stack<string> AddRange(IEnumerable<string> collection)
        {
            foreach (var item in collection)
            {
                stack.Push(item);
            }

            return stack;
        }
    }
}
