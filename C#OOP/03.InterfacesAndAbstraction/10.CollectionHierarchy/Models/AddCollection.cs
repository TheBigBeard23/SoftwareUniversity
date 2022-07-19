using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection : ICollection
    {
        public AddCollection()
        {
            collection = new string[100];
        }
        public AddCollection(string[] array)
            : base()
        {
            for (int i = 0; i < array.Length; i++)
            {
                collection[i] = array[i];
            }
        }
        public string[] collection { get; private set; }
    }
}
