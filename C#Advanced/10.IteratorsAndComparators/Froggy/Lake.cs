using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] stones;
        public Lake(IEnumerable<int> stones)
        {
            this.stones = (int[])stones;
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i++)
            {
                yield return stones[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  
    }
}
