using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public abstract class Collection<T> : IAddable<T>
    {
        private int lastIdx;
        protected Collection(int size)
        {
            this.Items = new T[size];
            lastIdx = 0;
        }
        protected T[] Items { get; }
        public virtual int Add(T obj)
        {
            this.Items[lastIdx++] = obj;

            return lastIdx - 1;
        }
    }
}
