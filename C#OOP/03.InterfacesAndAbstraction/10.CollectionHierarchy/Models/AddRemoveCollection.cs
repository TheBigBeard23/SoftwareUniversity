using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : Collection, IAddRemoveCollection
    {
        public string Remove()
        {
            var item = Items[Items.Count - 1];
            Items.RemoveAt(Items.Count - 1);

            return item;
        }
    }
}
