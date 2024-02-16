using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection<T> : Collection<T>, IRemoveable<T>
    {
        private int lastIdx;
        private int addIndex;
        public AddRemoveCollection(int size)
            : base(size)
        {
            addIndex = 0;
        }
        public override int Add(T obj)
        {
            if (lastIdx == 0)
            {
                this.Items[lastIdx] = obj;
            }
            else
            {
                for (int i = lastIdx; i > 0; i--)
                {
                    this.Items[i] = this.Items[i - 1];
                }
                this.Items[addIndex] = obj;
            }

            lastIdx++;
            return addIndex;
        }
        public T Remove()
        {
            T item = this.Items[lastIdx - 1];
            this.Items[lastIdx - 1] = default(T);
            lastIdx--;

            return item;

        }
    }
}
