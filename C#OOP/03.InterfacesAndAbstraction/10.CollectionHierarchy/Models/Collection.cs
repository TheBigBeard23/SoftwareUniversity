using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public abstract class Collection : IAddCollection
    {
        protected Collection()
        {
            Items = new List<string>();
        }
        protected List<string> Items { get; }
        public virtual int Add(string item)
        {
            Items.Add(item);
            return 0;
        }
    }
}
