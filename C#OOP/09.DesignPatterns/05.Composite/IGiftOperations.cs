using System;
using System.Collections.Generic;
using System.Text;

namespace CompositeDemo
{
    public interface IGiftOperations
    {
        void Add(GiftBase gift);
        void Remove(GiftBase gift);
    }
}
