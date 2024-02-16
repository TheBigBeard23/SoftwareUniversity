using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddCollection<T> : Collection<T>
    {
        public AddCollection(int size)
            : base(size)
        {
        }
    }
}
