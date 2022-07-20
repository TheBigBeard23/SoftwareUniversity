using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : Collection, IMyList
    {
        public int Used => Items.Count;

        public string Remove()
        {
            var item = Items[0];
            Items.RemoveAt(0);

            return item;
        }
    }
}
