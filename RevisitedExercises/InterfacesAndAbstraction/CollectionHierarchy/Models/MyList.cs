using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList<T> : Collection<T>, ICountable, IRemoveable<T>
    {
        private int lastIdx = 0;
        private int addIndex = 0;
        public MyList(int size)
            : base(size)
        {
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
            T item = this.Items[0];

            for (int i = 0; i < lastIdx - 1; i++)
            {
                this.Items[i] = this.Items[i + 1];
            }
            this.Items[lastIdx - 1] = default(T);
            lastIdx--;

            return item;
        }
        public int Used => this.Items.Count();
    }
}
