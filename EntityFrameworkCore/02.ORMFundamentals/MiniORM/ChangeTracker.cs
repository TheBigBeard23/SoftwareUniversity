using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Metadata;

namespace MiniORM
{
    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly List<T> _allEntities;
        private readonly List<T> _added;
        private readonly List<T> _removed;

        private ChangeTracker()
        {
            _added = new List<T>();
            _removed = new List<T>();
        }
        public ChangeTracker(IEnumerable<T> entities)
            : this()
        {
            _allEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<T> AllEntities
            => _allEntities.AsReadOnly();

        public IReadOnlyCollection<T> Added
            => _added.AsReadOnly();

        public IReadOnlyCollection<T> Removed
            => _removed.AsReadOnly();

        public void Add(T entity)
            => _added.Add(entity);

        public void Remove(T entity)
            => _removed.Add(entity);

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            List<T> modifiedEntities = new List<T>();
            PropertyInfo[] primaryKeys = typeof(T)
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (T proxyEntity in AllEntities)
            {
                object[] primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity)
                    .ToArray();

                T entity = dbSet.Entities
                    .Single(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));

                bool isModified = IsModified(proxyEntity, entity);
            }
        }

        private static IEnumerable<object> GetPrimaryKeyValues(PropertyInfo[] primaryKeys, T proxyEntity)
        {
            throw new NotImplementedException();
        }

        private static List<T>? CloneEntities(IEnumerable<T> entities)
        {
            List<T> clonedEntities = new List<T>();
            PropertyInfo[] propertiesToClone = typeof(T)
                .GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                .ToArray();

            foreach (T entity in entities)
            {
                T entityToClone = Activator.CreateInstance<T>();
                foreach (PropertyInfo property in propertiesToClone)
                {
                    object value = property.GetValue(entity);
                    property.SetValue(entityToClone, value);
                }
            }

            return clonedEntities;
        }
    }
}